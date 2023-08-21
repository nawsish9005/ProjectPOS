using Microsoft.EntityFrameworkCore;
using ProjectPOS.Models;

namespace ProjectPOS.Data
{
    public class ApiTestDbContext: DbContext
    {
        public ApiTestDbContext(DbContextOptions<ApiTestDbContext> options):base(options)
        {
            
        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
