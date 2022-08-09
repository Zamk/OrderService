using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;

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
