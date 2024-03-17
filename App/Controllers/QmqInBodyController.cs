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
    public class QmqInBodyController : Controller
    {
        private readonly qmessageContext _context;

        public QmqInBodyController(qmessageContext context)
        {
            _context = context;
        }

        // GET: QmqInBody
        public async Task<IActionResult> Index()
        {
            var qmessageContext = _context.QMQ_IN_BODies.Include(q => q.QMQ_IN_HEADER);
            return View(await qmessageContext.ToListAsync());
        }

        // GET: QmqInBody/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_IN_BODY = await _context.QMQ_IN_BODies
                .Include(q => q.QMQ_IN_HEADER)
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_IN_BODY == null)
            {
                return NotFound();
            }

            return View(qMQ_IN_BODY);
        }

        // GET: QmqInBody/Create
        public IActionResult Create()
        {
            ViewData["SOURCE"] = new SelectList(_context.QMQ_IN_HEADERs, "SOURCE", "SOURCE");
            return View();
        }

        // POST: QmqInBody/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SOURCE,MESSAGE_ID,FIELD_SEQ,FEATURE,VALUE")] QMQ_IN_BODY qMQ_IN_BODY)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qMQ_IN_BODY);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SOURCE"] = new SelectList(_context.QMQ_IN_HEADERs, "SOURCE", "SOURCE", qMQ_IN_BODY.SOURCE);
            return View(qMQ_IN_BODY);
        }

        // GET: QmqInBody/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_IN_BODY = await _context.QMQ_IN_BODies.FindAsync(id);
            if (qMQ_IN_BODY == null)
            {
                return NotFound();
            }
            ViewData["SOURCE"] = new SelectList(_context.QMQ_IN_HEADERs, "SOURCE", "SOURCE", qMQ_IN_BODY.SOURCE);
            return View(qMQ_IN_BODY);
        }

        // POST: QmqInBody/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SOURCE,MESSAGE_ID,FIELD_SEQ,FEATURE,VALUE")] QMQ_IN_BODY qMQ_IN_BODY)
        {
            if (id != qMQ_IN_BODY.SOURCE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qMQ_IN_BODY);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QMQ_IN_BODYExists(qMQ_IN_BODY.SOURCE))
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
            ViewData["SOURCE"] = new SelectList(_context.QMQ_IN_HEADERs, "SOURCE", "SOURCE", qMQ_IN_BODY.SOURCE);
            return View(qMQ_IN_BODY);
        }

        // GET: QmqInBody/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_IN_BODY = await _context.QMQ_IN_BODies
                .Include(q => q.QMQ_IN_HEADER)
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_IN_BODY == null)
            {
                return NotFound();
            }

            return View(qMQ_IN_BODY);
        }

        // POST: QmqInBody/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var qMQ_IN_BODY = await _context.QMQ_IN_BODies.FindAsync(id);
            _context.QMQ_IN_BODies.Remove(qMQ_IN_BODY);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QMQ_IN_BODYExists(string id)
        {
            return _context.QMQ_IN_BODies.Any(e => e.SOURCE == id);
        }
    }
}
