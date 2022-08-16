namespace OrderService.iikoTransportApi.Models
{
    public class DeliveryOrderInfo
    {
        public Guid Id { get; set; }
        public string ExternalNumber { get; set; }
        public Guid OrganizationId { get; set; }
        public long Timestamp { get; set; }
        public string CreationStatus { get; set; }
        public ErrorInfo ErrorInfo { get; set; }

    }
}
