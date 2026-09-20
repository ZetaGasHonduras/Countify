using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.ProductAccounts;

internal static class ProductAccountRules
{
    public static async Task<string?> ValidateAsync(
        IUnitOfWork unitOfWork,
        Guid productId,
        Guid? qualityId,
        Guid inventoryAccountId,
        Guid incomeAccountId,
        Guid costAccountId,
        Guid? productAccountId,
        CancellationToken cancellationToken)
    {
        var productExists = await unitOfWork.Products.ExistsAsync(
            p => p.Id == productId, cancellationToken);

        if (!productExists)
            return "El producto indicado no existe.";

        if (qualityId is not null)
        {
            var qualityExists = await unitOfWork.Qualities.ExistsAsync(
                q => q.Id == qualityId.Value, cancellationToken);

            if (!qualityExists)
                return "La calidad indicada no existe.";
        }

        if (!await AccountExistsAsync(unitOfWork, inventoryAccountId, cancellationToken))
            return "La cuenta de inventario indicada no existe.";

        if (!await AccountExistsAsync(unitOfWork, incomeAccountId, cancellationToken))
            return "La cuenta de ingreso indicada no existe.";

        if (!await AccountExistsAsync(unitOfWork, costAccountId, cancellationToken))
            return "La cuenta de costo indicada no existe.";

        var duplicate = await unitOfWork.ProductAccounts.ExistsAsync(
            a => a.ProductId == productId
                && a.QualityId == qualityId
                && a.Id != productAccountId,
            cancellationToken);

        if (duplicate)
            return "Ya existe una configuración para ese producto y calidad.";

        return null;
    }

    private static async Task<bool> AccountExistsAsync(
        IUnitOfWork unitOfWork, Guid accountId, CancellationToken cancellationToken)
        => await unitOfWork.Accounts.ExistsAsync(a => a.Id == accountId, cancellationToken);
}