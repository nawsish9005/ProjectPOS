using Microsoft.EntityFrameworkCore;
using ProjectPosClient.Models;

namespace ProjectPosClient.Data
{
    public class ClientDbContext:DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options):base(options)
        {
            
        }

        public virtual DbSet<Invoice>? Invoices { get; set; }
        public virtual DbSet<InvoiceDetail>? InvoiceDetails { get; set; }
    }
}
