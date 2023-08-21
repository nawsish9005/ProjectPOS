using Microsoft.EntityFrameworkCore;
using ProjectPos.Client.Models;

namespace ProjectPos.Client.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Invoice>? Invoices { get; set; }
        public virtual DbSet<InvoiceDetails>? InvoiceDetailss { get; set; }
    }
}
