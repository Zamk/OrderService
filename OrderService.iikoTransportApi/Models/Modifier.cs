using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.iikoTransportApi.Models
{
    public class Modifier
    {
        public Guid Id { get; set; }
        public int DefaultAmount { get; set; }
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public bool Required { get; set; }
        public bool HideIfDefaultAmount { get; set; }
        public bool Splittable { get; set; }
        public int FreeOfChargeAmount { get; set; }


    }
}
