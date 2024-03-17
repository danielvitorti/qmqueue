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
    public class QmqOutErrorLogHController : Controller
    {
        private readonly qmessageContext _context;

        public QmqOutErrorLogHController(qmessageContext context)
        {
            _context = context;
        }

        // GET: QmqOutErrorLogH
        public async Task<IActionResult> Index()
        {
            var qmessageContext = _context.QMQ_OUT_ERRORLOG_Hs.Include(q => q.QMQ_OUT_HEADER);
            return View(await qmessageContext.ToListAsync());
        }

        // GET: QmqOutErrorLogH/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_ERRORLOG_H = await _context.QMQ_OUT_ERRORLOG_Hs
                .Include(q => q.QMQ_OUT_HEADER)
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_OUT_ERRORLOG_H == null)
            {
                return NotFound();
            }

            return View(qMQ_OUT_ERRORLOG_H);
        }

        // GET: QmqOutErrorLogH/Create
        public IActionResult Create()
        {
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE");
            return View();
        }

        // POST: QmqOutErrorLogH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SOURCE,MESSAGE_ID,DATE_TIME_ERROR,ERROR_TEXT")] QMQ_OUT_ERRORLOG_H qMQ_OUT_ERRORLOG_H)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qMQ_OUT_ERRORLOG_H);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE", qMQ_OUT_ERRORLOG_H.SOURCE);
            return View(qMQ_OUT_ERRORLOG_H);
        }

        // GET: QmqOutErrorLogH/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_ERRORLOG_H = await _context.QMQ_OUT_ERRORLOG_Hs.FindAsync(id);
            if (qMQ_OUT_ERRORLOG_H == null)
            {
                return NotFound();
            }
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE", qMQ_OUT_ERRORLOG_H.SOURCE);
            return View(qMQ_OUT_ERRORLOG_H);
        }

        // POST: QmqOutErrorLogH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SOURCE,MESSAGE_ID,DATE_TIME_ERROR,ERROR_TEXT")] QMQ_OUT_ERRORLOG_H qMQ_OUT_ERRORLOG_H)
        {
            if (id != qMQ_OUT_ERRORLOG_H.SOURCE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qMQ_OUT_ERRORLOG_H);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QMQ_OUT_ERRORLOG_HExists(qMQ_OUT_ERRORLOG_H.SOURCE))
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
            ViewData["SOURCE"] = new SelectList(_context.QMQ_OUT_HEADERs, "SOURCE", "SOURCE", qMQ_OUT_ERRORLOG_H.SOURCE);
            return View(qMQ_OUT_ERRORLOG_H);
        }

        // GET: QmqOutErrorLogH/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_ERRORLOG_H = await _context.QMQ_OUT_ERRORLOG_Hs
                .Include(q => q.QMQ_OUT_HEADER)
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_OUT_ERRORLOG_H == null)
            {
                return NotFound();
            }

            return View(qMQ_OUT_ERRORLOG_H);
        }

        // POST: QmqOutErrorLogH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var qMQ_OUT_ERRORLOG_H = await _context.QMQ_OUT_ERRORLOG_Hs.FindAsync(id);
            _context.QMQ_OUT_ERRORLOG_Hs.Remove(qMQ_OUT_ERRORLOG_H);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QMQ_OUT_ERRORLOG_HExists(string id)
        {
            return _context.QMQ_OUT_ERRORLOG_Hs.Any(e => e.SOURCE == id);
        }
    }
}
