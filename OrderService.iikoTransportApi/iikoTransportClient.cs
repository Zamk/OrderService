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
        private readonly TokenStorage _tokenStorage;

        public iikoTransportClient()
        {
            _tokenStorage = new TokenStorage();
        }

        //requests
        public async Task<AccessTokenResponse> GetAccessTokenAsync(string apiLogin)
        {
            var request = new AccessTokenRequest(apiLogin);

            var client = GetClient();

            var responseMessage = await client.PostAsJsonAsync("/api/1/access_token", request);
            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadFromJsonAsync<AccessTokenResponse>();
            
            return result;
        }

        public async Task<OrganizationsResponse> GetOrganizationsAsync(string apiLogin)
        {
            var request = new OrganizationsRequest();

            var client = GetAutorizedClient(apiLogin);
            
            var responseMessage = await client.PostAsJsonAsync("/api/1/organizations", request);

            var result = await responseMessage.Content.ReadFromJsonAsync<OrganizationsResponse>();

            return result;
        }


        //Client factory
        public HttpClient GetAutorizedClient(string apiLogin)
        {
            HttpClient client = GetClient();

            if (_tokenStorage.Token == null)
            {
                _tokenStorage.Token = GetAccessTokenAsync(apiLogin).Result.Token;
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenStorage.Token);

            return client;
        }
        
        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            return client;
        }
    }
}
