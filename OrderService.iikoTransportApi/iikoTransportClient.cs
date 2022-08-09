﻿using System;
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
using OrderService.iikoTransportApi.Interfaces;


namespace OrderService.iikoTransportApi
{
    public class iikoTransportClient : IiikoTransportClient
    {
        private readonly string _url = "https://api-ru.iiko.services/";
        private readonly TokenStorage _tokenStorage;

        /// <summary>
        /// Конструктор класса iikoTransportClient, возвращает клиент iikoTransport
        /// </summary>
        /// <param name="apiLogin">Получается на стороне iikoTransport, необходим для получения токена</param>
        public iikoTransportClient(string apiLogin)
        {
            _tokenStorage = new TokenStorage(apiLogin);
        }

        /// <summary>
        /// Метод получает токен доступа для взамодействия с api
        /// </summary>
        
        /// <returns>Возвращает AccessTokenResponse, содержащий Token </returns>
        public async Task<AccessTokenResponse> GetAccessTokenAsync()
        {
            var request = new AccessTokenRequest(_tokenStorage.ApiKey);

            var client = GetClient();

            var responseMessage = await client.PostAsJsonAsync("/api/1/access_token", request);
            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadFromJsonAsync<AccessTokenResponse>();
            
            return result;
        }

        /// <summary>
        /// Метод получает список организаций, доступных по данному apiLogin
        /// </summary>
        /// <returns>Возвращает OrganizationsResponse, содержащий List<Organization> </returns>
        public async Task<OrganizationsResponse> GetOrganizationsAsync()
        {
            var request = new OrganizationsRequest();

            var client = GetAutorizedClient();
            
            var responseMessage = await client.PostAsJsonAsync("/api/1/organizations", request);

            var result = await responseMessage.Content.ReadFromJsonAsync<OrganizationsResponse>();

            return result;
        }

        //public async Task<TerminalGroupsResponse> GetTerminalGroupsAsync()
        //{

        //}


        /// <summary>
        /// Получает экземпляр HttpClient, настроенный и авторизованный для работы с iikoTransport API
        /// </summary>
        /// <returns>HttpClient с парамерами авторизации и uri сервера iikoTransport</returns>
        public HttpClient GetAutorizedClient()
        {
            HttpClient client = GetClient();

            var token = _tokenStorage.GetToken(this);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Result);

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
