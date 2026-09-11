using FluentValidation;

namespace Countify.Application.Features.Roles.Commands.UpdateRolePermissions;

public class UpdateRolePermissionsCommandValidator : AbstractValidator<UpdateRolePermissionsCommand>
{
    public UpdateRolePermissionsCommandValidator()
    {
        RuleFor(x => x.RoleId).NotEmpty();
        RuleFor(x => x.PermissionIds).NotEmpty()
            .WithMessage("Debe seleccionar al menos un permiso.");
        RuleForEach(x => x.PermissionIds).GreaterThan(0);
    }
}