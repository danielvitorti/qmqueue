using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QMessage;
using QMessage.Models;

namespace QMessage.Controllers
{
    public class QmqOutBodyController : Controller
    {
        private readonly qmessageContext _context;

        public QmqOutBodyController(qmessageContext context)
        {
            _context = context;
        }

        // GET: QmqOutBody
        public async Task<IActionResult> Index()
        {
            var qmessageContext = _context.QMQ_OUT_BODies.Include(q => q.QMQ_OUT_HEADER);
            return View(await qmessageContext.ToListAsync());
        }

        // GET: QmqOutBody/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_BODY = await _context.QMQ_OUT_BODies
                .Include(q => q.QMQ_OUT_HEADER)
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_OUT_BODY == null)
            {
                return NotFound();
            }

            return View(qMQ_OUT_BODY);
        }

        // GET: QmqOutBody/Create
        public IActionResult Create()
        {
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE");
            return View();
        }

        // POST: QmqOutBody/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SOURCE,MESSAGE_ID,FIELD_SEQ,FEATURE,VALUE")] QMQ_OUT_BODY qMQ_OUT_BODY)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qMQ_OUT_BODY);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE", qMQ_OUT_BODY.SOURCE);
            return View(qMQ_OUT_BODY);
        }

        // GET: QmqOutBody/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_BODY = await _context.QMQ_OUT_BODies.FindAsync(id);
            if (qMQ_OUT_BODY == null)
            {
                return NotFound();
            }
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE", qMQ_OUT_BODY.SOURCE);
            return View(qMQ_OUT_BODY);
        }

        // POST: QmqOutBody/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SOURCE,MESSAGE_ID,FIELD_SEQ,FEATURE,VALUE")] QMQ_OUT_BODY qMQ_OUT_BODY)
        {
            if (id != qMQ_OUT_BODY.SOURCE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qMQ_OUT_BODY);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QMQ_OUT_BODYExists(qMQ_OUT_BODY.SOURCE))
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
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE", qMQ_OUT_BODY.SOURCE);
            return View(qMQ_OUT_BODY);
        }

        // GET: QmqOutBody/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_BODY = await _context.QMQ_OUT_BODies
                .Include(q => q.QMQ_OUT_HEADER)
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_OUT_BODY == null)
            {
                return NotFound();
            }

            return View(qMQ_OUT_BODY);
        }

        // POST: QmqOutBody/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var qMQ_OUT_BODY = await _context.QMQ_OUT_BODies.FindAsync(id);
            _context.QMQ_OUT_BODies.Remove(qMQ_OUT_BODY);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QMQ_OUT_BODYExists(string id)
        {
            return _context.QMQ_OUT_BODies.Any(e => e.SOURCE == id);
        }
    }
}
