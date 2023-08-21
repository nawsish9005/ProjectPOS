using System.ComponentModel.DataAnnotations;

namespace ProjectPosClient.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public string OrderNumber { get; set; } = "";
        public string PayMethod { get; set; } = "";
        public decimal TotalAmount { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }
}
