using System.Xml.Serialization;

namespace transactioApp.Models.Xml
{
    public class PaymentDetails 
    {
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }

        [XmlElement(ElementName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
    }
}
