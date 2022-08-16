using OrderService.iikoTransportApi.Models;
using OrderService.iikoTransportApi.Interfaces;

namespace OrderService.iikoTransportApi.Responses
{
    public class OrganizationsResponse : IResponse
    {
        public Guid CorrelationId { get; set; }

        public List<Organization> Organizations { get; set; }
    }
}
