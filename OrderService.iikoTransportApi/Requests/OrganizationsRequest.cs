using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;


namespace OrderService.iikoTransportApi.Requests
{
    public class OrganizationsRequest : IRequest
    {
        public List<Organization> ? Organizations { get; set; }

        public OrganizationsRequest()
        {
            Organizations = new List<Organization>();
            Organizations.Add(new Organization());
        }
    }
}
