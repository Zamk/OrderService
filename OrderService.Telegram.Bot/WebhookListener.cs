using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using OrderService.Telegram.Bot.Models;

namespace OrderService.Telegram.Bot;

public class WebhookListener : IDisposable
{
    public Action<Update> OnUpdate;
    
    private readonly HttpListener _server;
    private bool _isRunning;
    
    public WebhookListener(string url = "http://192.168.1.3:88/webhook/")
    {
        _server = new HttpListener();
        _server.Prefixes.Add(url);
        _isRunning = false;
    }

    public void Start()
    {
        _server.Start();
        DoWork();
        _isRunning = true;
    }

    public void Stop()
    {
        _isRunning = false;
    }
    private async void DoWork()
    {
        while (_isRunning)
        {
            try
            {
                var context = await _server.GetContextAsync();

                var request = context?.Request;

                var json = new StreamReader(request?.InputStream)?.ReadToEnd();

                Console.WriteLine($"Recived update: {json}");

                var update = JsonConvert.DeserializeObject<Update>(json);

                byte[] buffer = Encoding.UTF8.GetBytes("ok");
                var response = context.Response;
                response.ContentLength64 = buffer.Length;
                
                await response.OutputStream.WriteAsync(buffer);
                await response.OutputStream.FlushAsync();
                
                OnUpdate?.Invoke(update);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
        _server.Stop();
    }

    public void Dispose()
    {
        _server.Stop();
        _server.Close();
    }
}