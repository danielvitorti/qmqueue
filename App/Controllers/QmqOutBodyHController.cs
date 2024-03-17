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
    public class QmqOutBodyHController : Controller
    {
        private readonly qmessageContext _context;

        public QmqOutBodyHController(qmessageContext context)
        {
            _context = context;
        }

        // GET: QmqOutBodyH
        public async Task<IActionResult> Index()
        {
            var qmessageContext = _context.QMQ_OUT_BODY_Hs.Include(q => q.QMQ_OUT_HEADER);
            return View(await qmessageContext.ToListAsync());
        }

        // GET: QmqOutBodyH/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_BODY_H = await _context.QMQ_OUT_BODY_Hs
                .Include(q => q.QMQ_OUT_HEADER)
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_OUT_BODY_H == null)
            {
                return NotFound();
            }

            return View(qMQ_OUT_BODY_H);
        }

        // GET: QmqOutBodyH/Create
        public IActionResult Create()
        {
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE");
            return View();
        }

        // POST: QmqOutBodyH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SOURCE,MESSAGE_ID,FIELD_SEQ,FEATURE,VALUE")] QMQ_OUT_BODY_H qMQ_OUT_BODY_H)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qMQ_OUT_BODY_H);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE", qMQ_OUT_BODY_H.SOURCE);
            return View(qMQ_OUT_BODY_H);
        }

        // GET: QmqOutBodyH/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_BODY_H = await _context.QMQ_OUT_BODY_Hs.FindAsync(id);
            if (qMQ_OUT_BODY_H == null)
            {
                return NotFound();
            }
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE", qMQ_OUT_BODY_H.SOURCE);
            return View(qMQ_OUT_BODY_H);
        }

        // POST: QmqOutBodyH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SOURCE,MESSAGE_ID,FIELD_SEQ,FEATURE,VALUE")] QMQ_OUT_BODY_H qMQ_OUT_BODY_H)
        {
            if (id != qMQ_OUT_BODY_H.SOURCE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qMQ_OUT_BODY_H);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QMQ_OUT_BODY_HExists(qMQ_OUT_BODY_H.SOURCE))
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
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE", qMQ_OUT_BODY_H.SOURCE);
            return View(qMQ_OUT_BODY_H);
        }

        // GET: QmqOutBodyH/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_BODY_H = await _context.QMQ_OUT_BODY_Hs
                .Include(q => q.QMQ_OUT_HEADER)
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_OUT_BODY_H == null)
            {
                return NotFound();
            }

            return View(qMQ_OUT_BODY_H);
        }

        // POST: QmqOutBodyH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var qMQ_OUT_BODY_H = await _context.QMQ_OUT_BODY_Hs.FindAsync(id);
            _context.QMQ_OUT_BODY_Hs.Remove(qMQ_OUT_BODY_H);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QMQ_OUT_BODY_HExists(string id)
        {
            return _context.QMQ_OUT_BODY_Hs.Any(e => e.SOURCE == id);
        }
    }
}
