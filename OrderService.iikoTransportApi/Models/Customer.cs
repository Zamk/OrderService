using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.iikoTransportApi.Models
{
    public class Customer
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Comment { get; set; }
        string Birthdate { get; set; }
        string Email { get; set; }

        //todo: ENUM Gender
        public string Gender { get; set; }

    }
}
