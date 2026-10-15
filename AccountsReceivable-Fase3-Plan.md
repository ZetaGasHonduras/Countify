# Cuentas por Cobrar (FASE 3 del roadmap maestro) — plan de cierre

> Documento de trabajo. Complementa `ROADMAP.md` y `API-CONTRACT-FASE1.md` del repo legacy
> (`gfmendoza27-systemaccounting-…`). La FASE 3 corresponde a CxC en el roadmap maestro
> (Cadexsa → Countify). Ese roadmap lista CxC como FASE 3 y CxP como FASE 4.

## 1. Estado actual en Countify

Ya implementado (backend + frontend):

- `CustomerType`, `Customer`, `AccountsReceivableConcept`, `AccountsReceivableDocument`
  (`Create`/`Update`/`Void`/`Lines`=Aplicar), `pending`, movimientos del cliente + export CSV/PDF.
- Generación de partida (`AccountsReceivablePostingFactory`), migración `20260923201709_AddFaseSix`.

## 2. Decisión de modelado (validada contra el legacy)

En el legacy, recibos y notas **no son tablas independientes**, son herencia de `CXCDocumentos`:

```csharp
public class CXCRecibos : CXCDocumentos, ITransaccion
public class CXCNotaDeCreditos : CXCDocumentos
public class CXCNotaDeDebito : CXCDocumentos
```

Por lo tanto, **fusionarlas en `AccountsReceivableDocument` con discriminador (concepto) es
correcto** y es el mapeo 1-a-1 real. El roadmap las listaba como "entidad nueva" por prolijidad.

### Mapeo campo a campo (CXCDocumentos → AccountsReceivableDocument)

| Legacy | Countify | Estado |
|---|---|---|
| `Documento` | `DocumentNo` | OK |
| `ConceptoCXC` | `ConceptId` | OK |
| `Cliente` | `CustomerId` | OK |
| `Fecha` / `Vence` | `Date` / `DueDate` | OK |
| `Referencia` / `Aplica` | `Reference` / `AppliesTo` | OK |
| `Departamento` / `Proyecto` | `DepartmentId` / `ProjectId` | OK |
| `Moneda` / `Factor` / `Monto` | `CurrencyId` / `ExchangeRate` / `Amount` | OK |
| `Observaciones` / `Anulado` / `Partida` | `Notes` / `IsVoided` / `JournalEntryId` | OK |
| `Diferencia`, `MontoLocal`, `SaldoPendiente`, `Debito`/`Credito` | calculados en queries | OK |
| `CXCDoHijosCollection` / `CXCDoHijosPagadosCollection` | `Lines` | OK (verificar bidireccional) |
| `Adjunto` (FileData) | `AccountsReceivableDocumentAttachment` | **OK** |
| `PartidaGID` / `CntDocumentoHijo` | `JournalEntryId` | OK |
| `CXCNotaDeCredito.*` fiscal | campos fiscales en `AccountsReceivableDocument` | **OK** |
| `CXCNotaDeDebito` | concepto tipo Debit + campos fiscales | **OK** |
| `ControlesFiscales` | `FiscalControl` | **OK** |

## 3. Decisiones tomadas

1. **Portar datos fiscales** de Notas de Crédito y Débito tal cual (CAI, rangos, fechas, motivo, números).
2. **Nota de Débito** se modela como **concepto/tipo** dentro de `ReceivableDocument` (no entidad aparte).
3. **Adjuntos**: agregar soporte.

## 4. Qué falta implementar (backend)

### 4.1 Campos fiscales en `AccountsReceivableDocument` (nullable; solo N/C y N/D)

Del legacy `CXCNotaDeCreditos` / `CXCNotaDeDebito`:

- `FiscalControlId` FK (← `ControlFiscal`)
- `InvoiceCAI` string? (← `CAIFactura`)
- `CAI` string?
- `RangeFrom` / `RangeTo` string? (← `RangoDesde` / `RangoHasta`)
- `EmissionLimitDate` DateTime? (← `FechaLimiteEmision`)
- `EmissionDate` DateTime? (← `FechaEmision`)
- `NoteNumber` string? unique (← `NumeroDeNotaDeCreditos` / `NumeroDeNotaDebito`)
- `CreditNoteReason` enum? (← `MotivoNotaCredito`)
- `FiscalConcept` string(100)? (← `Concepto` de la nota)

### 4.2 Nueva entidad `FiscalControl` (← `ControlesFiscales`)

`Id`, `CompanySettingsId` FK? (`Control`), `DocumentType` enum, `EmissionDate`, `Branch` (Sucursal),
`EmissionPoint` (PuntoDeEmision), `CAI`, `RangeFrom`, `RangeTo`, `EmissionLimit`,
`IsActive`, `InvoiceNumber` int, `CreditNoteNumber` int, `WarningNumber` int.
Acción "Activar" y `AvisoFiscal()` (aviso de rangos por terminar / finalizados).

### 4.3 Enums nuevos

- `FiscalDocumentType` { Invoicing = 0, DebitNote = 1, CreditNote = 2, DispatchGuide = 3, Retention = 4 }
- `CreditNoteReason` { Annulment, Return, Discounts, Other }  (← `Anulacion`, `Devolucion`, `Descuentos`, `Otros`)

### 4.4 Numeración

- **Recibo**: `NextReceiptNumber` = `max(ReceiptNumber)+1` (en Create/Update/`AccountsReceivableDocumentDraftFactory`),
  equivalente funcional al contador de configuración del legacy. Se puede corregir manualmente con el
  permiso `CanEditReceiptNumber` vía `PUT /accounts-receivable-documents/{id}/receipt-number`.
- **Nota**: formato legacy `{Sucursal}-{PuntoDeEmision}-06-{8 dígitos}` (06 = nota de crédito).
  Al crear: toma el `FiscalControl` activo del tipo correspondiente, incrementa el contador y valida
  **agotamiento del rango** (bloqueo) y **vencimiento** (`EmissionLimitDate`). El aviso de rangos por
  terminar se refleja en la lista de Controles Fiscales (columna "Restantes" con `WarningNumber`).

### 4.5 Conceptos (seeder)

- Ya existen: `Factura` (Invoice), `Anulación` (InvoiceCancellation), `RECIBO` (IsReceipt), `Anticipo` (DownPayment).
- **Agregar `NOTA DE DEBITO`** (tipo Debit, generatePosting según legacy).
- Confirmar que `NOTA DE CREDITO`/anulación cubre el flujo de N/C con datos fiscales.

### 4.6 Adjuntos

- Entidad `AccountsReceivableDocumentAttachment` (o `AttachmentPath` + `AttachmentName`).
- Endpoint de subida (multipart) y descarga; permisos.
- Decidir almacenamiento (filesystem local vs blob) — **pendiente definir**.

### 4.7 Permisos

- `CanCreate/Edit/View/Void` para notas (crédito y débito).
- `CanEditReceiptNumber` (← `Controles.EditarNumeroDeRecibo`).
- Recordatorio: no existe endpoint catálogo de permisos; se hardcodean + seed en migración.

### 4.8 Migración EF

- Nombre sugerido: `AddReceivableFiscalNotesAndAttachments`.
- Incluye: columnas fiscales nuevas, tabla `FiscalControls`, tabla de adjuntos, seed de conceptos/permisos.

## 5. Frontend (Angular, `Countify-PanelUser`)

- Formulario de documento: mostrar campos fiscales cuando el concepto es N/C o N/D
  (CAI, rangos, número, fecha límite, motivo, concepto fiscal) en modo readonly/auto.
- Impresión de recibo con `ReceiptNumber`.
- Subida de adjuntos en el modal.
- Reflejar permisos (`CanEditReceiptNumber`, notas).

## 6. Migración de datos (FASE 14, cuando toque)

- `CXCDocumentos` → `ReceivableDocument` por discriminador.
- `CXCRecibos` → + `ReceiptNumber` / correlativo.
- `CXCNotaDeCreditos` / `CXCNotaDeDebito` → + columnas fiscales.
- `CXCDocumentosHijo` → `AccountsReceivableDocumentLine`.
- `ControlesFiscales` → `FiscalControl`.
- Vistas `VSTCXCEstadoDeCuenta` / `VSTCXCSaldos` → **no** son tablas: se portan como consultas.

## 7. Consultas/Reportes

- **Estado de Cuenta con aging** (← `VSTCXCSaldos`): **OK**. Buckets Corriente / 1-30 / 31-60 / 61-90 /
  91-120 / 121+ (6 buckets, como el legacy), calculados al corte sobre el saldo pendiente de cada cargo
  según su vencimiento. Se expone en `GET /accounts-receivable-documents/movements` (objeto `aging`),
  en las exportaciones CSV/PDF y en la pantalla "Movimientos del Cliente".
- Transferencia de saldos: **no era feature real** del legacy (no existe en `Cadexsa.Module`);
  no se implementa.

## 8. Criterio de terminado (FASE 3)

Mantenimientos completos · relaciones y detalles · validaciones equivalentes · acciones migradas ·
permisos de pantalla y acción · estados y bloqueos · integración con partidas · consulta/reporte
principal · pruebas de casos normales y excepciones · conciliación contra el sistema viejo.

## 9. Fuera de alcance aquí

CxP (FASE 4 del maestro), Facturación (5), Inventarios (6), Producción (7), Nómina (8).
Presupuestos (9) y Reportes (10) ya están adelantados parcialmente.

## 10. Estado de cierre (FASE 3) — actualizado

Los 7 ítems del roadmap para FASE 3 están implementados (backend + frontend):

| Ítem roadmap | Entidad | Estado |
|---|---|---|
| Clientes | `Customer` | OK |
| Tipos de Clientes | `CustomerType` | OK |
| Movimientos de CxC | `ReceivableDocument` | OK |
| Conceptos de CxC | `ReceivableConcept` | OK |
| Nota de Crédito | concepto tipo Credit + datos fiscales | OK |
| Recibos | `ReceiptNumber` + `CorrelativoAsignado` | OK |
| Estado de Cuenta (consulta) | aging `VSTCXCSaldos` | OK |

Pendientes descartados/verificados:

- Transferencia de saldos → no existía en el legacy; no se implementa.
- Impresión de recibo → el legacy `CXCRecibos` no tenía acción de impresión; no se implementa.

Migración aplicada: `20261014195831_AddReceivableFiscalNotesAndAttachments`.

