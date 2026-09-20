# Flujo bancario

Los movimientos creados en `POST /api/banks/transactions` generan una partida `SourceModule.Bank` balanceada con la cuenta contable del banco y `CounterpartAccountId`. La actualización reutiliza la misma partida y sus líneas, por lo que no duplica partidas. La fecha se valida contra períodos cerrados.

La conciliación se crea en `POST /api/banks/reconciliations` con los IDs de movimientos seleccionados. Cada movimiento conserva `BankReconciliationId`; una conciliación cerrada no puede modificarse y desmarcar requiere `CanUnreconcileBankTransactions`.

El estado de cuenta está disponible en `GET /api/banks/statement` y su exportación CSV en `GET /api/banks/statement/export`, con `bankAccountId`, `fromDate` y `toDate`.

## Base de datos pendiente

No se generó migración por requerimiento. El nombre sugerido para la siguiente migración es `AddBankTransactionCounterpartAndReconciliationLink`.
