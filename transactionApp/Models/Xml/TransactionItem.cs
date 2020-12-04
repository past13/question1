using System.Xml.Serialization;

namespace transactioApp.Models.Xml
{
    public class TransactionItem 
    {
        [XmlAttribute("id")]
        public string TransactionId { get; set; }

        [XmlElement(ElementName = "TransactionDate")]
        public string TransactionDate { get; set; }
        
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "PaymentDetails")]
        public PaymentDetails PaymentDetails { get; set; }
    }
}


