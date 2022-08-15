using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.iikoTransportApi.Models
{
    public class ErrorInfo
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string AdditionalData { get; set; }
    }
}
