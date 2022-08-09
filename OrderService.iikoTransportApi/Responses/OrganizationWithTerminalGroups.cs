using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.iikoTransportApi.Models;


namespace OrderService.iikoTransportApi.Responses
{
    public  class OrganizationWithTerminalGroups
    {
        public Guid OrganizationId { get; set; }
        public List<TerminalGroup> Items { get; set; }
    }
}
