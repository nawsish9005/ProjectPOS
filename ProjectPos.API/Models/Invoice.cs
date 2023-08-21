using System.ComponentModel.DataAnnotations;

namespace ProjectPos.Client.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public string OrderNumber { get; set; } = "";
        public string PayMethod { get; set; } = ""; 
        public decimal TotalAmount { get; set; }
        public List<InvoiceDetails> InvoiceDetailss { get; set; }=new List<InvoiceDetails>();
    }
}
