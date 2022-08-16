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
