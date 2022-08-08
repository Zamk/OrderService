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

        public TokenStorage()
        {
            _expires = DateTime.Now;
            _token = null;
        }

        public string ? Token 
        { 
            get
            {
                return DateTime.Now < _expires ? _token : null;
            } 
            set
            {
                _token = value;
                _expires = DateTime.Now + TimeSpan.FromMinutes(15);
            }
        }
    }
}
