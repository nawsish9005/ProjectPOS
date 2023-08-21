using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPosClient.Data;
using ProjectPosClient.Models;

namespace ProjectPosClient.Controllers
{
    public class MasterController : Controller
    {
        private readonly ClientDbContext _context;
        //constructor
        public MasterController(ClientDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Invoice> invoice;
            invoice = _context.Invoices.ToList();
            return View(invoice);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceDetails.Add(new InvoiceDetail() { DetailsId = 1 });
            invoice.InvoiceDetails.Add(new InvoiceDetail() { DetailsId = 2 });
            invoice.InvoiceDetails.Add(new InvoiceDetail() { DetailsId = 3 });
            return View(invoice);
        }

        [HttpPost]
        public IActionResult Create(Invoice invoice)
        {
            foreach (InvoiceDetail invoiceDetails in invoice.InvoiceDetails)
            {
                if (invoiceDetails.ProductName == null || invoiceDetails.ProductName.Length == 0)
                {
                    invoice.InvoiceDetails.Remove(invoiceDetails);
                }
            }
            _context.Add(invoice);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Invoice invoice = _context.Invoices.Include(e => e.InvoiceDetails)
                .Where(a => a.InvoiceId == id).FirstOrDefault();
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }
        [HttpPost]
        public IActionResult Edit(Invoice invoice)
        {
            List<InvoiceDetail> invDetail = _context.InvoiceDetails
                .Where(d=>d.InvoiceId == invoice.InvoiceId).ToList();
            _context.InvoiceDetails.RemoveRange(invDetail);
            _context.SaveChanges();

                _context.Invoices.Update(invoice);
                _context.Entry(invoice).State = EntityState.Modified;
                _context.InvoiceDetails.AddRange(invoice.InvoiceDetails);
                _context.SaveChanges();
             
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Invoice? inv = _context.Invoices
                .Include(u => u.InvoiceDetails)
                .Where(a => a.InvoiceId == id).FirstOrDefault();
            return View(inv);
        }
    }
}
