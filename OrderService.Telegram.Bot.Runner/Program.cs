using System.Text;
using System.Net;
using OrderService.Telegram.Bot;
using OrderService.Telegram.Bot.Models;
using Newtonsoft.Json;

HttpListener server = new HttpListener();
server.Prefixes.Add("http://192.168.1.3:88/webhook/");
server.Start();

ApiClient apiClient = new ApiClient(Environment.GetEnvironmentVariable("TELEGRAM_BOT_KEY"));

while (true)
{
    try
    {
        // получаем контекст
        var context = await server.GetContextAsync();

        if (context == null || context.Request == null)
            continue;

        var request = context.Request;

        var json = new StreamReader(request.InputStream)?.ReadToEnd();

        Console.WriteLine($"Recived update: {json}");

        var update = JsonConvert.DeserializeObject<Update>(json);

        byte[] buffer = Encoding.UTF8.GetBytes("ok");

        var response = context.Response;
        // отправляемый в ответ код htmlвозвращает
        response.ContentLength64 = buffer.Length;
        // получаем поток ответа и пишем в него ответ

        await response.OutputStream.WriteAsync(buffer);
        await response.OutputStream.FlushAsync();

        apiClient.SendMessage((int)update?.Message?.Chat?.Id, $"Hello, {update?.Message?.From?.FirstName}! Your message is: \"{update?.Message?.Text}\"");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex}");
    }
}
server.Stop();
server.Close();