using System;
using System.ComponentModel.DataAnnotations;

namespace transactioApp.Models.Dto
{
    using Enums;
    public class TransactionDto
    {
        [Key]
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus Status  { get; set; }
        public PaymentDetailsDto PaymentDetails { get; set; }
    }
}