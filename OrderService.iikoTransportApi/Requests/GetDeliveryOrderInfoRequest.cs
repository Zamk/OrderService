using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
