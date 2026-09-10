namespace Countify.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendPasswordResetAsync(string toEmail, string firstName, string token);
}