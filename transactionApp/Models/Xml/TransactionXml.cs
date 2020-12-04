using System.Collections.Generic;
using System.Xml.Serialization;

namespace transactioApp.Models.Xml
{
    [XmlRoot("MyDocument", Namespace = "transactions")]
    public class TransactionXml
    {
        [XmlArray]
        [XmlArrayItem(ElementName = "Transaction")]
        public List<TransactionItem> Transactions { get; set; }
    }
}