namespace OrderService.iikoTransportApi.Models
{
    public class Size
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public bool IsDefault { get; set; }
    }
}
