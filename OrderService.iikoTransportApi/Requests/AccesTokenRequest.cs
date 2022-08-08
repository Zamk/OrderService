using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
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
