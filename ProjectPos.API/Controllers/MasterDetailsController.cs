using Microsoft.AspNetCore.Mvc;
using ProjectPos.Client.Data;
using ProjectPos.Client.Models;

namespace ProjectPos.Client.Controllers
{
    public class MasterDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MasterDetailsController(ApplicationDbContext context)
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
            invoice.InvoiceDetailss.Add(new InvoiceDetails() { DetailsId = 1 });
            invoice.InvoiceDetailss.Add(new InvoiceDetails() { DetailsId = 2 });
            invoice.InvoiceDetailss.Add(new InvoiceDetails() { DetailsId = 3 });
            return View(invoice);
        }

        [HttpPost]
        public IActionResult Create(Invoice invoice)
        {
            foreach(InvoiceDetails invoiceDetails in invoice.InvoiceDetailss)
            {
                if(invoiceDetails.ProductName==null || invoiceDetails.ProductName.Length==0)
                {
                    invoice.InvoiceDetailss.Remove(invoiceDetails);
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
            var invoiceDb = _context.Invoices.Find(id);
            if (invoiceDb == null)
            {
                return NotFound();
            }
            return View(invoiceDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Invoice obj)
        {
            if (ModelState.IsValid)
            {
                _context.Invoices.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var invoice = _context.Invoices.Find(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var objInv = _context.Invoices.Find(id);
            if (objInv == null)
            {
                return NotFound();
            }
            _context.Invoices.Remove(objInv);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
