using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.iikoTransportApi.Models
{
    public class OrderedProduct
    {
        public Guid ProductId { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
    }
}
