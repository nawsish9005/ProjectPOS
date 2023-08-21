using System.ComponentModel.DataAnnotations;

namespace ProjectPosClient.Models
{
    public class InvoiceDetail
    {
        [Key]
        public int DetailsId { get; set; }
        public int InvoiceId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
