namespace Countify.Application.Common.Interfaces;

public interface ICurrentUserService
{
    (Guid UserId, string UserName) GetCurrentUser();
}