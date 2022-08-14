using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.iikoTransportApi.Models
{
    public class OrderInfo
    {
        public Guid Id { get; set; }
        public string ExternalNumber { get; set; }
        public Guid OrganizationId { get; set; }
        public long Timestamp { get; set; }
        public string CreationStatus { get; set; }

    }
}
