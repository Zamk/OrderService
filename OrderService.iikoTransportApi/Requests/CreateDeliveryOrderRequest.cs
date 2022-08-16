using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;


namespace OrderService.iikoTransportApi.Requests
{
    public class CreateDeliveryOrderRequest : IRequest
    {
        public Guid OrganizationId { get; set; }
        public Guid TerminalGroupId { get; set; }
        public CreateDeliveryOrder Order { get; set; }

        public CreateDeliveryOrderRequest(Guid organizationId, Guid terminalGroupId, CreateDeliveryOrder order )
        {
            OrganizationId = organizationId;
            TerminalGroupId = terminalGroupId;
            Order = order;
        }

    }
}
