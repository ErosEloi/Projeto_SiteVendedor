using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoSiteVendas.Data;
using ProjetoSiteVendas.Models;

namespace ProjetoSiteVendas.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly ProjetoSiteVendasContext _context;

        public SalesRecordsController(ProjetoSiteVendasContext context)
        {
            _context = context;
        }

        // GET: SalesRecords
        public async Task<IActionResult> Index()
        {
              return _context.SaleRecord != null ? 
                          View(await _context.SaleRecord.ToListAsync()) :
                          Problem("Entity set 'ProjetoSiteVendasContext.SaleRecord'  is null.");
        }

        // GET: SalesRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SaleRecord == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SaleRecord
                .FirstOrDefaultAsync(m => m.id == id);
            if (salesRecord == null)
            {
                return NotFound();
            }

            return View(salesRecord);
        }

        // GET: SalesRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Date,Amount,Status")] SalesRecord salesRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesRecord);
        }

        // GET: SalesRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SaleRecord == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SaleRecord.FindAsync(id);
            if (salesRecord == null)
            {
                return NotFound();
            }
            return View(salesRecord);
        }

        // POST: SalesRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Date,Amount,Status")] SalesRecord salesRecord)
        {
            if (id != salesRecord.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesRecordExists(salesRecord.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(salesRecord);
        }

        // GET: SalesRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SaleRecord == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SaleRecord
                .FirstOrDefaultAsync(m => m.id == id);
            if (salesRecord == null)
            {
                return NotFound();
            }

            return View(salesRecord);
        }

        // POST: SalesRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SaleRecord == null)
            {
                return Problem("Entity set 'ProjetoSiteVendasContext.SaleRecord'  is null.");
            }
            var salesRecord = await _context.SaleRecord.FindAsync(id);
            if (salesRecord != null)
            {
                _context.SaleRecord.Remove(salesRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesRecordExists(int id)
        {
          return (_context.SaleRecord?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
