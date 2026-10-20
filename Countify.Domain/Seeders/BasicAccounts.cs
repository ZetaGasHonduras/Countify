using System.Linq;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicAccounts
{
    public static readonly Account Assets = NewAccount(1, "1", "Activos");
    public static readonly Account CurrentAssets = NewAccount(2, "1.1", "Activos Corrientes");
    public static readonly Account Cash = NewAccount(4, "1.1.1.001", "Caja General", operable: true);
    public static readonly Account Banks = NewAccount(7, "1.1.2.001", "Cuenta de Cheques", operable: true, bank: true);
    public static readonly Account AccountsReceivable = NewAccount(11, "1.1.3.001", "Cuenta por Cobrar Clientes", operable: true, auxCxc: true);
    public static readonly Account SuppliersPayableLocal = NewAccount(55, "2.1.1.1.001", "Locales", operable: true, auxCxp: true);
    public static readonly Account SuppliersPayableForeign = NewAccount(56, "2.1.1.1.002", "Extranjeros", operable: true, auxCxp: true);
    public static readonly Account FurnitureAndEquipment = NewAccount(30, "1.2.1.1.002", "Instalaciones", operable: true, auxAsset: true);
    public static readonly Account ServiceRevenue = NewAccount(100, "4.1.1", "Ventas brutas", operable: true);
    public static readonly Account CostOfSales = NewAccount(107, "5.1.1", "Costo de venta = costo directo", operable: true);
    public static readonly Account OperatingExpenses = NewAccount(111, "6.1.1.1", "Sueldos y salarios", operable: true);
    public static readonly Account CapitalStock = NewAccount(91, "3.1.1", "Capital pagado", operable: true);

    public static Account[] Items { get; } =
    [
        // ===== 1 ACTIVOS =====
        NewAccount(1, "1", "Activos"),
        NewAccount(2, "1.1", "Activos Corrientes"),
        NewAccount(3, "1.1.1", "Caja"),
        NewAccount(4, "1.1.1.001", "Caja General", operable: true),
        NewAccount(5, "1.1.1.002", "Caja Chica", operable: true),
        NewAccount(6, "1.1.2", "Bancos"),
        NewAccount(7, "1.1.2.001", "Cuenta de Cheques", operable: true, bank: true),
        NewAccount(8, "1.1.2.002", "Cuenta de Ahorros", operable: true, bank: true),
        NewAccount(9, "1.1.2.003", "Certificados de Depósitos", operable: true, bank: true),
        NewAccount(10, "1.1.3", "Cuentas por Cobrar"),
        NewAccount(11, "1.1.3.001", "Cuenta por Cobrar Clientes", operable: true, auxCxc: true),
        NewAccount(12, "1.1.3.002", "Cuentas por Cobrar Empleados", operable: true),
        NewAccount(13, "1.1.3.003", "Cuentas por Cobrar Otros", operable: true),
        NewAccount(14, "1.1.4", "Anticipo a Justificar"),
        NewAccount(15, "1.1.4.001", "Anticipos por Cobrar Empleados", operable: true),
        NewAccount(16, "1.1.5", "Inventarios"),
        NewAccount(17, "1.1.5.001", "Inv. de materiales", operable: true),
        NewAccount(18, "1.1.5.002", "Inv. de accesorios", operable: true),
        NewAccount(19, "1.1.5.003", "Inv. de papelería y útiles de oficina", operable: true),
        NewAccount(20, "1.1.5.004", "Inv. de materiales de limpieza", operable: true),
        NewAccount(21, "1.1.5.005", "Inv. de mercadería", operable: true),
        NewAccount(22, "1.1.5.006", "Inv. de granos básicos", operable: true),
        NewAccount(23, "1.1.6", "Otros activos corrientes"),
        NewAccount(24, "1.1.6.001", "Impuestos anticipados", operable: true),
        NewAccount(25, "1.1.6.002", "Crédito fiscal impuestos", operable: true),
        NewAccount(26, "1.2", "Propiedad, Planta y Equipo"),
        NewAccount(27, "1.2.1", "Activos tangibles"),
        NewAccount(28, "1.2.1.1", "Activos depreciables"),
        NewAccount(29, "1.2.1.1.001", "Inmuebles", operable: true, auxAsset: true),
        NewAccount(30, "1.2.1.1.002", "Instalaciones", operable: true, auxAsset: true),
        NewAccount(31, "1.2.1.2", "Depreciación acumulada"),
        NewAccount(32, "1.2.1.2.001", "Inmuebles dep", operable: true),
        NewAccount(33, "1.2.1.2.002", "Instalaciones dep", operable: true),
        NewAccount(34, "1.2.1.3", "Activos no depreciables"),
        NewAccount(35, "1.2.1.3.001", "Terreno #1", operable: true),
        NewAccount(36, "1.2.2", "Activos Intangibles"),
        NewAccount(37, "1.2.2.1", "Marcas y Patentes", operable: true),
        NewAccount(38, "1.2.2.2", "Software", operable: true),
        NewAccount(39, "1.2.2.3", "Crédito mercantil", operable: true),
        NewAccount(40, "1.3", "Otros activos"),
        NewAccount(41, "1.3.1", "Activos Diferidos"),
        NewAccount(42, "1.3.1.1", "Gastos de constitución", operable: true),
        NewAccount(43, "1.3.1.2", "Gastos de instalación", operable: true),
        NewAccount(44, "1.3.1.3", "Gastos pagados por anticipo", operable: true),
        NewAccount(45, "1.3.2", "Amortización"),
        NewAccount(46, "1.3.2.1", "Gastos de constitución", operable: true),
        NewAccount(47, "1.3.2.2", "Gastos de instalación", operable: true),
        NewAccount(48, "1.3.3", "Otros Activos Varios"),
        NewAccount(49, "1.3.3.001", "Depósito entregado en garantía", operable: true),
        NewAccount(50, "1.3.3.002", "Inmuebles entregados en garantía", operable: true),

        // ===== 2 PASIVO =====
        NewAccount(51, "2", "Pasivo"),
        NewAccount(52, "2.1", "Pasivos corrientes - corto plazo"),
        NewAccount(53, "2.1.1", "Cuentas por pagar"),
        NewAccount(54, "2.1.1.1", "Proveedores"),
        NewAccount(55, "2.1.1.1.001", "Locales", operable: true, auxCxp: true),
        NewAccount(56, "2.1.1.1.002", "Extranjeros", operable: true, auxCxp: true),
        NewAccount(57, "2.1.1.2", "Servicios por pagar"),
        NewAccount(58, "2.1.1.2.001", "Energía eléctrica", operable: true),
        NewAccount(59, "2.1.1.2.002", "Comunicaciones - telefonía, cable, internet", operable: true),
        NewAccount(60, "2.1.1.2.003", "Agua potable - acueductos", operable: true),
        NewAccount(61, "2.1.1.2.004", "Tren de aseo", operable: true),
        NewAccount(62, "2.1.1.3", "Nóminas por pagar"),
        NewAccount(63, "2.1.1.3.001", "Sueldos por pagar", operable: true),
        NewAccount(64, "2.1.1.3.002", "Derechos por pagar - indemnizaciones", operable: true),
        NewAccount(65, "2.1.1.3.003", "Prestaciones sociales", operable: true),
        NewAccount(66, "2.1.1.3.004", "Aportes patronales y personales (IHSS, RAP, INFOP, fondos de pensiones, AMDC)", operable: true),
        NewAccount(67, "2.1.1.3.005", "Provisiones por pagar", operable: true),
        NewAccount(68, "2.1.1.3.006", "Décimo tercer mes por pagar", operable: true),
        NewAccount(69, "2.1.1.3.007", "Décimo cuarto mes por pagar", operable: true),
        NewAccount(70, "2.1.1.3.008", "Vacaciones por pagar", operable: true),
        NewAccount(71, "2.1.1.4", "Impuestos por pagar"),
        NewAccount(72, "2.1.1.4.001", "Impuesto sobre la renta", operable: true),
        NewAccount(73, "2.1.1.4.002", "Impuesto sobre ventas", operable: true),
        NewAccount(74, "2.1.1.4.003", "Retenciones en la fuente por pagar", operable: true),
        NewAccount(75, "2.1.1.4.004", "Impuesto sobre ganancias de capital", operable: true),
        NewAccount(76, "2.1.1.4.005", "Impuesto sobre volumen de ventas", operable: true),
        NewAccount(77, "2.1.1.5", "Documentos por pagar - corto plazo"),
        NewAccount(78, "2.1.1.5.001", "Pagaré", operable: true),
        NewAccount(79, "2.1.1.5.002", "Letras de cambio", operable: true),
        NewAccount(80, "2.1.1.6", "Préstamos bancarios - corto plazo"),
        NewAccount(81, "2.1.1.6.001", "Hipotecarios", operable: true, auxLoan: true),
        NewAccount(82, "2.1.1.6.002", "Prendarios", operable: true, auxLoan: true),
        NewAccount(83, "2.1.1.6.003", "Fiduciarios", operable: true, auxLoan: true),
        NewAccount(84, "2.2", "Pasivos a largo plazo"),
        NewAccount(85, "2.2.1", "Préstamos bancarios - largo plazo"),
        NewAccount(86, "2.2.1.001", "Hipotecarios", operable: true, auxLoan: true),
        NewAccount(87, "2.2.1.002", "Prendarios", operable: true, auxLoan: true),
        NewAccount(88, "2.2.1.003", "Fiduciarios", operable: true, auxLoan: true),

        // ===== 3 PATRIMONIO =====
        NewAccount(89, "3", "PATRIMONIO - CAPITAL CONTABLE"),
        NewAccount(90, "3.1", "Capital"),
        NewAccount(91, "3.1.1", "Capital pagado", operable: true),
        NewAccount(92, "3.1.2", "Reservas"),
        NewAccount(93, "3.1.2.001", "Reserva de capital", operable: true),
        NewAccount(94, "3.1.2.002", "Reserva legal", operable: true),
        NewAccount(95, "3.1.3", "Resultados"),
        NewAccount(96, "3.1.3.1", "Resultados años anteriores (utilidad+/pérdidas-)", operable: true),
        NewAccount(97, "3.1.3.2", "Resultados del ejercicio (utilidad+/pérdidas-)", operable: true),

        // ===== 4 INGRESOS =====
        NewAccount(98, "4", "INGRESOS"),
        NewAccount(99, "4.1", "Ingresos operacionales / por ventas"),
        NewAccount(100, "4.1.1", "Ventas brutas", operable: true),
        NewAccount(101, "4.1.1.1", "Devoluciones sobre ventas", operable: true),
        NewAccount(102, "4.1.1.2", "Rebajas sobre ventas", operable: true),
        NewAccount(103, "4.1.1.3", "Descuentos sobre ventas", operable: true),
        NewAccount(104, "4.1.2", "Ventas netas"),

        // ===== 5 COSTOS =====
        NewAccount(105, "5", "COSTOS"),
        NewAccount(106, "5.1", "Costos operacionales"),
        NewAccount(107, "5.1.1", "Costo de venta = costo directo", operable: true),

        // ===== 6 GASTOS =====
        NewAccount(108, "6", "GASTOS"),
        NewAccount(109, "6.1", "Gastos operacionales"),
        NewAccount(110, "6.1.1", "Gastos de administración"),
        NewAccount(111, "6.1.1.1", "Sueldos y salarios", operable: true),
        NewAccount(112, "6.1.1.2", "Servicios públicos", operable: true),
        NewAccount(113, "6.1.1.3", "Impuestos", operable: true),
        NewAccount(114, "6.1.1.4", "Aportaciones patronales", operable: true),
        NewAccount(115, "6.1.1.5", "Papelería y útiles", operable: true),
        NewAccount(116, "6.1.1.6", "Depreciaciones", operable: true),
        NewAccount(117, "6.1.1.7", "Amortizaciones", operable: true),
        NewAccount(118, "6.1.1.8", "Mantenimiento", operable: true),
        NewAccount(119, "6.1.1.9", "Combustibles", operable: true),
        NewAccount(120, "6.1.1.10", "Viáticos", operable: true),
        NewAccount(121, "6.1.2", "Gastos de venta"),
        NewAccount(122, "6.1.2.1", "Sueldos y salarios", operable: true),
        NewAccount(123, "6.1.2.2", "Servicios públicos", operable: true),
        NewAccount(124, "6.1.2.3", "Impuestos", operable: true),
        NewAccount(125, "6.1.2.4", "Aportaciones patronales", operable: true),
        NewAccount(126, "6.1.2.5", "Papelería y útiles", operable: true),
        NewAccount(127, "6.1.2.6", "Depreciaciones", operable: true),
        NewAccount(128, "6.1.2.7", "Amortizaciones", operable: true),
        NewAccount(129, "6.1.2.8", "Mantenimiento", operable: true),
        NewAccount(130, "6.1.2.9", "Combustibles", operable: true),
        NewAccount(131, "6.1.2.10", "Publicidad", operable: true),
        NewAccount(132, "6.1.2.11", "Mercadeo", operable: true),
        NewAccount(133, "6.1.2.12", "Viáticos", operable: true),
        NewAccount(134, "6.1.3", "Gastos financieros"),
        NewAccount(135, "6.1.3.1", "Intereses por financiamiento", operable: true),
        NewAccount(136, "6.1.3.2", "Gastos bancarios"),
        NewAccount(137, "6.1.3.2.001", "Emisión de chequeras", operable: true),
        NewAccount(138, "6.1.3.2.002", "Servicios bancarios", operable: true),
        NewAccount(139, "6.1.3.2.003", "Diferencial cambiario", operable: true),
    ];

    private static Account NewAccount(
        int id, string code, string name,
        bool operable = false, bool auxCxc = false, bool auxCxp = false,
        bool auxLoan = false, bool auxAsset = false, bool bank = false)
        => new()
        {
            Id = Guid.Parse($"40000000-0000-0000-0000-000000{id:D6}"),
            Code = code,
            Name = name,
            IsOperable = operable,
            ParentCode = ParentCodeOf(code),
            Level = LevelOf(code),
            IsAuxCxc = auxCxc,
            IsAuxCxp = auxCxp,
            IsAuxLoan = auxLoan,
            IsAuxAsset = auxAsset,
            IsBankAccount = bank
        };

    private static int LevelOf(string code) => code.Split('.').Length;

    private static string? ParentCodeOf(string code)
    {
        var segments = code.Split('.');
        return segments.Length > 1 ? string.Join('.', segments.Take(segments.Length - 1)) : null;
    }
}