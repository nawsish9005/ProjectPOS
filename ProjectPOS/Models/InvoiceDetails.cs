using System.ComponentModel.DataAnnotations;

namespace ProjectPOS.Models
{
    public class InvoiceDetails
    {
        [Key]
        public int DetailsId { get; set; }
        public int InvoiceId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
