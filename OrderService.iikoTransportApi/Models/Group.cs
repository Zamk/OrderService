namespace OrderService.iikoTransportApi.Models
{
    public class Group
    {
        public List<string> ImageLinks { get; set; }
        public Guid ParentGroup { get; set; }
        public int Order { get; set; }
        public bool IsIncludedInMenu { get; set; }
        public bool isGroupModifier { get; set; }
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdditionalInfo { get; set; }
        public List<string> Tags { get; set; }
        public bool IsDeleted { get; set; }
        public string SeoDescription { get; set; }
        public string SeoText { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoTitle { get; set; }
    }
}
