using Countify.Application.Common.Interfaces;
using Quick.AutoInject.Services;

namespace Countify.Infrastructure.Services;

[ScopeService]
public class EmailService : IEmailService
{
    public Task SendPasswordResetAsync(string toEmail, string firstName, string token)
    {
        throw new NotImplementedException();
    }
}