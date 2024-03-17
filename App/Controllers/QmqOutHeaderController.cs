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
    public class QmqOutHeaderController : Controller
    {
        private readonly qmessageContext _context;

        public QmqOutHeaderController(qmessageContext context)
        {
            _context = context;
        }

        // GET: QmqOutHeader
        public async Task<IActionResult> Index()
        {
            return View(await _context.QMQ_OUT_HEADERs.ToListAsync());
        }

        // GET: QmqOutHeader/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_HEADER = await _context.QMQ_OUT_HEADERs
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_OUT_HEADER == null)
            {
                return NotFound();
            }

            return View(qMQ_OUT_HEADER);
        }

        // GET: QmqOutHeader/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QmqOutHeader/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SOURCE,MESSAGE_ID,TARGET,MESSAGE_TYPE,EXPIRATION_TIME,REMARKS,MSG_STATUS,DATE_TIME_IN,DATE_TIME_PROC,RETRY_COUNT")] QMQ_OUT_HEADER qMQ_OUT_HEADER)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qMQ_OUT_HEADER);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qMQ_OUT_HEADER);
        }

        // GET: QmqOutHeader/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_HEADER = await _context.QMQ_OUT_HEADERs.FindAsync(id);
            if (qMQ_OUT_HEADER == null)
            {
                return NotFound();
            }
            return View(qMQ_OUT_HEADER);
        }

        // POST: QmqOutHeader/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SOURCE,MESSAGE_ID,TARGET,MESSAGE_TYPE,EXPIRATION_TIME,REMARKS,MSG_STATUS,DATE_TIME_IN,DATE_TIME_PROC,RETRY_COUNT")] QMQ_OUT_HEADER qMQ_OUT_HEADER)
        {
            if (id != qMQ_OUT_HEADER.SOURCE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qMQ_OUT_HEADER);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QMQ_OUT_HEADERExists(qMQ_OUT_HEADER.SOURCE))
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
            return View(qMQ_OUT_HEADER);
        }

        // GET: QmqOutHeader/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_OUT_HEADER = await _context.QMQ_OUT_HEADERs
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_OUT_HEADER == null)
            {
                return NotFound();
            }

            return View(qMQ_OUT_HEADER);
        }

        // POST: QmqOutHeader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var qMQ_OUT_HEADER = await _context.QMQ_OUT_HEADERs.FindAsync(id);
            _context.QMQ_OUT_HEADERs.Remove(qMQ_OUT_HEADER);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QMQ_OUT_HEADERExists(string id)
        {
            return _context.QMQ_OUT_HEADERs.Any(e => e.SOURCE == id);
        }
    }
}
