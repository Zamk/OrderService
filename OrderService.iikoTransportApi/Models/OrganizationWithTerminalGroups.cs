namespace OrderService.iikoTransportApi.Models
{
    public  class OrganizationWithTerminalGroups
    {
        public Guid OrganizationId { get; set; }
        public List<TerminalGroup> Items { get; set; }
    }
}
