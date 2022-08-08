using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.iikoTransportApi.Models
{
    public class Organization
    {
        public string ResponseType { get; set; }
        public string Country { get; set; }
        public string RestaurantAddress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool UseUaeAddressingSystem { get; set; }    
        public string Version { get; set; }
        public string CurrencyIsoName { get; set; }
        public string CurrencyMinimumDenomination { get; set; }
        public string CountryPhoneCode { get; set; }
        public bool MarketingSourceRequiredInDelivery { get; set; }
        public string DefaultDeliveryCityId { get; set; }
        public string DeliveryCityIds { get; set; }
        public string DeliveryServiceType { get; set; }
        public string DefaultCallCenterPaymentTypeId { get; set; }
        public bool OrderItemCommentEnabled { get; set; }
        public string Inn { get; set; }
        public string AddressFormatType { get; set; }
        public bool IsConfirmationEnabled { get; set; }
        public int ConfirmAllowedIntervalInMinutes { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
