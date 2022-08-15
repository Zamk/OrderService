using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;

namespace OrderService.iikoTransportApi.Responses
{
    public class CreateDeliveryOrderResponse : IResponse
    {
        public Guid CorrelationId { get; set; }
        public DeliveryOrderInfo ? OrderInfo { get; set; }
        public string ? ErrorDescription { get; set; }
        public string ? Error { get; set; }
    }
}
