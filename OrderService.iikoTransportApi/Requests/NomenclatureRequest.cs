using OrderService.iikoTransportApi.Interfaces;


namespace OrderService.iikoTransportApi.Requests
{
    public class NomenclatureRequest : IRequest
    {
        public Guid OrganizationId { get; set; }
        public int StartRevision { get; set; }

        public NomenclatureRequest(Guid organizationId, int startRevision = 0)
        {
            OrganizationId = organizationId;
            StartRevision = startRevision;
        }
    }
}
