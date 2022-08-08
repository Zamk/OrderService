using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.iikoTransportApi.Interfaces
{
    public interface IResponse
    {
        public Guid CorrelationId { get; set; }
    }
}
