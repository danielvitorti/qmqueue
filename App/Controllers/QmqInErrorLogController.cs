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
    public class QmqInErrorLogController : Controller
    {
        private readonly qmessageContext _context;

        public QmqInErrorLogController(qmessageContext context)
        {
            _context = context;
        }

        // GET: QmqInErrorLog
        public async Task<IActionResult> Index()
        {
            var qmessageContext = _context.QMQ_IN_ERRORLOGs.Include(q => q.QMQ_IN_HEADER);
            return View(await qmessageContext.ToListAsync());
        }

        // GET: QmqInErrorLog/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_IN_ERRORLOG = await _context.QMQ_IN_ERRORLOGs
                .Include(q => q.QMQ_IN_HEADER)
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_IN_ERRORLOG == null)
            {
                return NotFound();
            }

            return View(qMQ_IN_ERRORLOG);
        }

        // GET: QmqInErrorLog/Create
        public IActionResult Create()
        {
            ViewData["SOURCE"] = new SelectList(_context.QMQ_IN_HEADERs, "SOURCE", "SOURCE");
            return View();
        }

        // POST: QmqInErrorLog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SOURCE,MESSAGE_ID,DATE_TIME_ERROR,ERROR_TEXT")] QMQ_IN_ERRORLOG qMQ_IN_ERRORLOG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qMQ_IN_ERRORLOG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SOURCE"] = new SelectList(_context.QMQ_IN_HEADERs, "SOURCE", "SOURCE", qMQ_IN_ERRORLOG.SOURCE);
            return View(qMQ_IN_ERRORLOG);
        }

        // GET: QmqInErrorLog/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_IN_ERRORLOG = await _context.QMQ_IN_ERRORLOGs.FindAsync(id);
            if (qMQ_IN_ERRORLOG == null)
            {
                return NotFound();
            }
            ViewData["SOURCE"] = new SelectList(_context.QMQ_IN_HEADERs, "SOURCE", "SOURCE", qMQ_IN_ERRORLOG.SOURCE);
            return View(qMQ_IN_ERRORLOG);
        }

        // POST: QmqInErrorLog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SOURCE,MESSAGE_ID,DATE_TIME_ERROR,ERROR_TEXT")] QMQ_IN_ERRORLOG qMQ_IN_ERRORLOG)
        {
            if (id != qMQ_IN_ERRORLOG.SOURCE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qMQ_IN_ERRORLOG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QMQ_IN_ERRORLOGExists(qMQ_IN_ERRORLOG.SOURCE))
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
            ViewData["SOURCE"] = new SelectList(_context.QMQ_IN_HEADERs, "SOURCE", "SOURCE", qMQ_IN_ERRORLOG.SOURCE);
            return View(qMQ_IN_ERRORLOG);
        }

        // GET: QmqInErrorLog/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_IN_ERRORLOG = await _context.QMQ_IN_ERRORLOGs
                .Include(q => q.QMQ_IN_HEADER)
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_IN_ERRORLOG == null)
            {
                return NotFound();
            }

            return View(qMQ_IN_ERRORLOG);
        }

        // POST: QmqInErrorLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var qMQ_IN_ERRORLOG = await _context.QMQ_IN_ERRORLOGs.FindAsync(id);
            _context.QMQ_IN_ERRORLOGs.Remove(qMQ_IN_ERRORLOG);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QMQ_IN_ERRORLOGExists(string id)
        {
            return _context.QMQ_IN_ERRORLOGs.Any(e => e.SOURCE == id);
        }
    }
}
