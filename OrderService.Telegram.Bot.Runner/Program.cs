using System.Text;
using System.Net;
using OrderService.Telegram.Bot;
using OrderService.Telegram.Bot.Models;
using Newtonsoft.Json;

HttpListener server = new HttpListener();
server.Prefixes.Add("http://192.168.1.3:88/webhook/");
server.Start();

var token = Environment.GetEnvironmentVariable("TELEGRAM_BOT_KEY");

if (token == null)
{
    throw new Exception("TELEGRAM_BOT_KEY not specified!");
}

ApiClient apiClient = new ApiClient(token);

while (true)
{
    try
    {
        // получаем контекст
        var context = await server.GetContextAsync();

        if (context == null || context.Request == null)
            continue;

        var json = new StreamReader(context.Request.InputStream)?.ReadToEnd();

        Console.WriteLine($"Recived update: {json}");

        if (json == null)
            continue;

        Update? update = null;
        try
        {
            update = JsonConvert.DeserializeObject<Update>(json);

            if (update == null)
                continue;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}\n---------------------------------------");
            continue;
        }
        finally
        {
            byte[] buffer = Encoding.UTF8.GetBytes("ok");
            var response = context.Response;
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer);
            await response.OutputStream.FlushAsync();
        }

        apiClient.SendMessage((int)update.Message.Chat.Id, $"Hello, {update.Message.From.FirstName}! Your message is: \"{update.Message.Text}\"");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fatal error: {ex.Message}");
        break;
    }
}
server.Stop();
server.Close();