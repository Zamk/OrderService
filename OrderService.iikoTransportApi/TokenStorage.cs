using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.iikoTransportApi
{
    public class TokenStorage
    {
        private string _token;
        private DateTime _expires;

        public string Token 
        { 
            get
            {
                return _token;
            } 
            private set
            {
                _token = value;
            }
        }
    }
}
