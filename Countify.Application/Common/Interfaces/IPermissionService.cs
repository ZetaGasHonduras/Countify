namespace Countify.Application.Common.Interfaces;

public interface IPermissionService
{
    Task<HashSet<string>> GetPermissionsAsync(string userId);
}