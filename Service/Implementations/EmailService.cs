using Dealership.Service.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Dealership.Service.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Dealership.Service.Implementations;
public class EmailService:IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public EmailService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public async Task SendRecoveryEmailAsync(string emailTo, string token)
    {
        var apiKey = _configuration["Brevo:ApiKey"];
        var senderEmail = _configuration["Brevo:SenderEmail"];
        var senderName = _configuration["Brevo:SenderName"];

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("app-key", apiKey);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var payload = new
        {
            sender = new { name = senderName, email = senderEmail },
            to = new[] { new { email = emailTo } },
            subject = "Recuperação de senha",
            htmlContent = $"<p>Seu código de recuperação é: <b>{token}</b></p>"
        };

        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://api.brevo.com/v3/smtp/email", content);

        if(!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Falha ao enviar email via api: {error}");
        }
    }
}
