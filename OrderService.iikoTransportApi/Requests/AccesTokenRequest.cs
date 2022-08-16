using OrderService.iikoTransportApi.Interfaces;


namespace OrderService.iikoTransportApi.Requests
{
    public class AccessTokenRequest : IRequest
    {
        public AccessTokenRequest(string apiLogin)
        {
            ApiLogin = apiLogin;
        }

        public string ApiLogin { get; set; }
    }
}
