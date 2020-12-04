using System.ComponentModel.DataAnnotations;

namespace transactioApp.Models.Dto
{
    public class PaymentDetailsDto
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode  { get; set; }
    }
}
