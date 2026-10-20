using Countify.Domain.Entities.Billing;

namespace Countify.Domain.Seeders;

/// <summary>
/// Métodos de pago iniciales (legacy: <c>MetodosDePago</c>). "Efectivo" queda
/// marcado como predeterminado (<c>Predefinido</c> en el legacy).
/// </summary>
public static class BasicPaymentMethods
{
    public static readonly PaymentMethod Cash = NewMethod(1, "Efectivo", isDefault: true);
    public static readonly PaymentMethod Card = NewMethod(2, "Tarjeta");
    public static readonly PaymentMethod Transfer = NewMethod(3, "Transferencia");
    public static readonly PaymentMethod Check = NewMethod(4, "Cheque");

    public static PaymentMethod[] Items { get; } = [Cash, Card, Transfer, Check];

    private static PaymentMethod NewMethod(int id, string name, bool isDefault = false)
        => new()
        {
            Id = Guid.Parse($"0f000000-0000-0000-0000-00000000000" + id),
            Name = name,
            IsDefault = isDefault,
        };
}
