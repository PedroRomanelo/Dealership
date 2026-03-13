namespace Dealership.Service.Interfaces;

public interface IEmailService
{
    Task SendRecoveryEmailAsync(string emailTo, string token);
}