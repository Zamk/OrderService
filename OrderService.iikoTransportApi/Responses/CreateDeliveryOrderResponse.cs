using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;

namespace OrderService.iikoTransportApi.Responses
{
    public class CreateDeliveryOrderResponse : IResponse
    {
        public Guid CorrelationId { get; set; }
        public OrderInfo OrderInfo { get; set; }
    }
}
