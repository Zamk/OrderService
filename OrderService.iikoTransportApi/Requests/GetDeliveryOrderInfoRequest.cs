using OrderService.iikoTransportApi.Interfaces;

namespace OrderService.iikoTransportApi.Requests
{
    public class GetDeliveryOrderInfoRequest : IRequest
    {
        public Guid OrganizationId { get; set; }
        public List<Guid> ? OrderIds { get; set; }
        public List<string> ? SourceKeys { get; set; }

        public GetDeliveryOrderInfoRequest(Guid organizationId, List<Guid> orderIds)
        {
            OrganizationId = organizationId;
            OrderIds = orderIds;
        }

    }
}
