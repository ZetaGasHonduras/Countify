using System.Reflection;
using Countify.Domain.Entities.Auth;

namespace Countify.Domain.Authorization;

public class Permissions
{
    public static readonly Permission CanCreateUsers = Permission.Create(1, nameof(CanCreateUsers), "Crear usuarios.");
    public static readonly Permission CanEditUsers = Permission.Create(2, nameof(CanEditUsers),   "Editar usuarios.");
    public static readonly Permission CanDeleteUsers = Permission.Create(3, nameof(CanDeleteUsers), "Eliminar usuarios.");
    public static readonly Permission CanViewUsers = Permission.Create(4, nameof(CanViewUsers),   "Ver usuarios.");
    
    public static readonly Permission CanCreateRoles = Permission.Create(5,  nameof(CanCreateRoles), "Crear roles.");
    public static readonly Permission CanEditRoles = Permission.Create(6, nameof(CanEditRoles),   "Editar roles y sus permisos.");
    public static readonly Permission CanDeleteRoles = Permission.Create(7, nameof(CanDeleteRoles), "Eliminar roles.");
    public static readonly Permission CanViewRoles = Permission.Create(8, nameof(CanViewRoles),   "Ver roles.");
    
    public static readonly Permission CanViewHistorie   = Permission.Create(9, nameof(CanViewHistorie),   "Ver historial.");
    
    public static Permission[] Items { get; } = typeof(Permissions)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(fieldInfo => fieldInfo.FieldType == typeof(Permission))
        .Select(fieldInfo => (Permission)fieldInfo.GetValue(null)!)
        .ToArray();
}