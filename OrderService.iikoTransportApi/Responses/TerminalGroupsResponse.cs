using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;

namespace OrderService.iikoTransportApi.Responses
{
    public class TerminalGroupsResponse : IResponse
    {
        public Guid CorrelationId { get; set; }

        public List<OrganizationWithTerminalGroups> TerminalGroups { get; set; }
    }
}
