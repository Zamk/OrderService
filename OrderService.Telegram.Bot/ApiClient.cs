using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderService.Telegram.Bot
{
    public class ApiClient
    {
        private string _apiBaseUrl = "https://api.telegram.org/";
        private string _token;

        public ApiClient(string token)
        {
            _token = token;
        }

        public bool SendMessage(int chatId, string message)
        {
            using var client = new HttpClient();
            
            var url = $"{_apiBaseUrl}bot{_token}/sendMessage?chat_id={chatId}&text={message}";

            return client.Send(new HttpRequestMessage(HttpMethod.Get, url)).IsSuccessStatusCode;
        }
    }
}