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
using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;


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

        /// <summary>
        /// Метод получает список терминальных групп по id организации для списка организаций
        /// </summary>
        /// <returns>Возвращает TerminalGroupsResponse, содержащий List<OrganizationWithTerminalGroups> </returns>
        public async Task<TerminalGroupsResponse> GetTerminalGroupsAsync(List<Guid> organizationIds)
        {
            var request = new TerminalGroupsRequest(organizationIds);

            var client = GetAutorizedClient();

            var responseMessage = await client.PostAsJsonAsync("/api/1/terminal_groups", request);

            var result = await responseMessage.Content.ReadFromJsonAsync<TerminalGroupsResponse>();

            return result;

        }
        
        /// <summary>
        /// Получает список номенклатуры внешнего меню, категорий, групп и размеров для заданной организации.
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public async Task<NomenclatureResponse> GetNomenclatureAsync(Guid organizationId)
        {
            var client = GetAutorizedClient();
            
            var request = new NomenclatureRequest(organizationId);

            var responseMessage = await client.PostAsJsonAsync("/api/1/nomenclature", request);

            var result = await responseMessage.Content.ReadFromJsonAsync<NomenclatureResponse>();

            return result;
        }

        /// <summary>
        /// Метод для отправки заказа доставки на терминальную грппу
        /// </summary>
        /// <param name="organizationId">Id организации, для которой создается доставка</param>
        /// <param name="terminalGroupId">Id терминальной группы, для которой создается доставка</param>
        /// <param name="order">Сущность заказа на доставку</param>
        /// <returns></returns>
        public async Task<CreateDeliveryOrderResponse> CreateDeliveryAsync(Guid organizationId, Guid terminalGroupId, CreateDeliveryOrder order)
        {
            var client = GetAutorizedClient();

            var request = new CreateDeliveryOrderRequest(organizationId, terminalGroupId, order);

            var responseMessage = await client.PostAsJsonAsync("/api/1/deliveries/create", request);
            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadFromJsonAsync<CreateDeliveryOrderResponse>();
            
            return result;
        }

        /// <summary>
        /// Метод получает информацию о заказах доставки по Id организации и списку Id заказовв
        /// </summary>
        /// <param name="organizationId">Id организации, для которой получаем информацию о доставках</param>
        /// <param name="orderIds">Список Id закаов, по которым получаем информацию о доставках </param>
        /// <returns></returns>
        public async Task<GetDeliveryOrderInfoResponse> GetDeliveryOrderInfo(Guid organizationId, List<Guid> orderIds)
        {
            var client = GetAutorizedClient();

            var request = new GetDeliveryOrderInfoRequest(organizationId, orderIds);

            var responseMessage = await client.PostAsJsonAsync("/api/1/deliveries/by_id", request);
            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadFromJsonAsync<GetDeliveryOrderInfoResponse>();

            return result;
        }

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
