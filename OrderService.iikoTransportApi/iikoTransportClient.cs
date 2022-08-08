using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using OrderService.iikoTransportApi.Requests;
using OrderService.iikoTransportApi.Responses;


namespace OrderService.iikoTransportApi
{
    public class iikoTransportClient
    {
        private readonly string _url = "https://api-ru.iiko.services/";

        public async Task<AccessTokenResponse> GetAccessToken(string apiLogin)
        {
            var request = new AccessTokenRequest(apiLogin);

            var client = GetClient();

            var responseMessage = await client.PostAsJsonAsync("/api/1/access_token", request);
            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadFromJsonAsync<AccessTokenResponse>();
            if (responseMessage == null) throw new HttpRequestException(responseMessage.StatusCode.ToString());
            return result;
        }
        
        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            return client;
        }
    }
}
