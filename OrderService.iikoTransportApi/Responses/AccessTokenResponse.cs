using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.iikoTransportApi.Interfaces;



namespace OrderService.iikoTransportApi.Responses
{
    public class AccessTokenResponse : IResponse
    {
        public Guid CorrelationId { get; set; }

        public string Token { get; set; }
    }
}
