using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;


namespace OrderService.iikoTransportApi.Responses
{
    public class GetDeliveryOrderInfoResponse : IResponse
    {
        public Guid CorrelationId { get; set; }
        public List<DeliveryOrderInfo> Orders { get; set; }
    }
}
