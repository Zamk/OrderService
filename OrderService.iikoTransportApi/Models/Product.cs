using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.iikoTransportApi.Models
{
    public class Product
    {
        public double FatAmount { get; set; }
        public double ProteinsAmount { get; set; }
        public double CarbohydratesAmount { get; set; }
        public double EnergyAmount { get; set; }
        public double FatFullAmount { get; set; }
        public double ProteinsFullAmount { get; set; }
        public double CarbohydratesFullAmount { get; set; }
        public double EnergyFullAmount { get; set; }
        public double Weight { get; set; }
        public Guid GroupId { get; set; }
        public Guid ProductCategoryId { get; set; }
        public string Type { get; set; }
        public string OrderItemType { get; set; }
        public Guid ModifierSchemaId { get; set; }
        public string ModifierSchemaName { get; set; }
        public bool Splittable { get; set; }
        public string MeasureUnit { get; set; }
        //"sizePrices": [],
        //"modifiers": [],
        public List<Modifier> Modifiers { get; set; }
        //"groupModifiers": [],
        public List<string> ImageLinks { get; set; }
        public bool DoNotPrintInCheque { get; set; }
        public Guid ParentGroup { get; set; }
        public int Order { get; set; }
        public string FullNameEnglish { get; set; }
        public bool UseBalanceForSell { get; set; }
        public bool CanSetOpenPrice { get; set; }
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
