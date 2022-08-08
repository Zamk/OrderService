using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
