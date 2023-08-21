using System.ComponentModel.DataAnnotations;

namespace ProjectPOS.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public string OrderNumber { get; set; } = "";
        public string PayMethod { get; set; } = "";
        public decimal TotalAmount { get; set; }
        public List<InvoiceDetails> InvoiceDetails { get; set; } = new List<InvoiceDetails>();
    }
}
