using OrderService.iikoTransportApi.Interfaces;


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
