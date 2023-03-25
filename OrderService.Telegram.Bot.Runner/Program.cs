using System.Text;
using System.Net;
using OrderService.Telegram.Bot;
using OrderService.Telegram.Bot.Models;
using Newtonsoft.Json;

internal class Program
{
    private static ApiClient _apiClient;
    private static WebhookListener _listener;
    private static async Task Main(string[] args)
    {
        _apiClient = new ApiClient(Environment.GetEnvironmentVariable("TELEGRAM_BOT_KEY"));
        _listener = new WebhookListener(Environment.GetEnvironmentVariable("TELEGRAM_WEBHOOK_LISTENER_ADDRESS"));
        _listener.OnUpdate += UpdateHandler;
        _listener.Start();
        
        Console.ReadKey();
        _listener.Stop();
    }

    public static void UpdateHandler(Update update)
    {
        _apiClient.SendMessage((int)update?.Message?.Chat?.Id, 
            $"Hello, {update?.Message?.From?.FirstName}! Your message is: \"{update?.Message?.Text}\"");
    }
}