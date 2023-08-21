using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPOS.Data;
using ProjectPOS.Models;

namespace ProjectPOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterController : Controller
    {
        private readonly ApiTestDbContext dbContext;

        public MasterController(ApiTestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        //get all data
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return await dbContext.Invoices.ToListAsync();
        }
        [HttpGet("{id}")]
        //get single data
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            //var invoice = await dbContext.Invoices.FindAsync(id);
            Invoice? invoice = dbContext.Invoices
                .Include(u => u.InvoiceDetails)
                .Where(a => a.InvoiceId == id).FirstOrDefault();
            if (invoice==null)
            {
                return NotFound();
            }

            return invoice;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInvoice(int id, Invoice invoice)
        {
            if(id!=invoice.InvoiceId)
            {
                return BadRequest();
            }
            dbContext.Entry(invoice).State=EntityState.Modified;
            return NoContent(); 
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            dbContext.Invoices.Add(invoice);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction("GetInvoice", new { id = invoice.InvoiceId }, invoice);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(long id)
        {
            var inv = await dbContext.Invoices.FindAsync(id);
            if(inv !=null)
            {
                dbContext.Remove(inv);
                await dbContext.SaveChangesAsync();
            }
            return NotFound();
        }
    }
}
