﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.iikoTransportApi.Interfaces;
using OrderService.iikoTransportApi.Models;


namespace OrderService.iikoTransportApi.Responses
{
    public class NomenclatureResponse : IResponse
    {
        public Guid CorrelationId { get; set; }
        public List<Group> Groups { get; set; }
        public List<ProductCategories> ProductCategories { get; set; }
        public List<Product> Products { get; set; }
        public List<Size> Sizes { get; set; }
        public int Revision { get; set; }

    }
}
