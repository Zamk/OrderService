using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;


namespace OrderService.iikoTransportApi.Requests
{
    public class TerminalGroupsRequest : IRequest
    {
        public List<Guid> OrganizationIds { get; set; }
        public bool IncludeDisabled { get; set; }

        public TerminalGroupsRequest(Guid organizationId, bool includeDeleted=false)
        {
            OrganizationIds = new List<Guid>();
            OrganizationIds.Add(organizationId);
            IncludeDisabled = includeDeleted;
        }

        public TerminalGroupsRequest(List<Guid> organizationIds, bool includeDeleted=false)
        {
            OrganizationIds = new List<Guid>(organizationIds);
            IncludeDisabled = includeDeleted;
        }
    }
}
