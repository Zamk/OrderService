using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;

namespace OrderService.iikoTransportApi.Responses
{
    public class TerminalGroupsResponse : IResponse
    {
        public Guid CorrelationId { get; set; }

        public Dictionary<Guid, List<TerminalGroup>> TerminalGroups { get; set; }
    }
}
