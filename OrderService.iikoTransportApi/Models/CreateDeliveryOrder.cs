using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.iikoTransportApi.Models
{
    public class CreateDeliveryOrder
    {
        public string Phone { get; set; }

        //todo : ENUM OrderServiceType
        public string OrderServiceType { get; set; }
        public string Comment { get; set; }
        public Customer Customer { get; set; }

        public List<OrderedProduct> Items { get; set; }

    }
}
