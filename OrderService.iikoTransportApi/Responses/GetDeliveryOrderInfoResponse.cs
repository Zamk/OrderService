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
