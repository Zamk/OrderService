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
        public long Revision { get; set; }

    }
}
