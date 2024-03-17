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
    public class QmqInHeaderController : Controller
    {
        private readonly qmessageContext _context;

        public QmqInHeaderController(qmessageContext context)
        {
            _context = context;
        }

        // GET: QmqInHeader
        public async Task<IActionResult> Index()
        {
            return View(await _context.QMQ_IN_HEADERs.ToListAsync());
        }

        // GET: QmqInHeader/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_IN_HEADER = await _context.QMQ_IN_HEADERs
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_IN_HEADER == null)
            {
                return NotFound();
            }

            return View(qMQ_IN_HEADER);
        }

        // GET: QmqInHeader/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QmqInHeader/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SOURCE,MESSAGE_ID,TARGET,MESSAGE_TYPE,EXPIRATION_TIME,REMARKS,MSG_STATUS,DATE_TIME_IN,DATE_TIME_PROC,RETRY_COUNT")] QMQ_IN_HEADER qMQ_IN_HEADER)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qMQ_IN_HEADER);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qMQ_IN_HEADER);
        }

        // GET: QmqInHeader/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_IN_HEADER = await _context.QMQ_IN_HEADERs.FindAsync(id);
            if (qMQ_IN_HEADER == null)
            {
                return NotFound();
            }
            return View(qMQ_IN_HEADER);
        }

        // POST: QmqInHeader/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SOURCE,MESSAGE_ID,TARGET,MESSAGE_TYPE,EXPIRATION_TIME,REMARKS,MSG_STATUS,DATE_TIME_IN,DATE_TIME_PROC,RETRY_COUNT")] QMQ_IN_HEADER qMQ_IN_HEADER)
        {
            if (id != qMQ_IN_HEADER.SOURCE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qMQ_IN_HEADER);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QMQ_IN_HEADERExists(qMQ_IN_HEADER.SOURCE))
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
            return View(qMQ_IN_HEADER);
        }

        // GET: QmqInHeader/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMQ_IN_HEADER = await _context.QMQ_IN_HEADERs
                .FirstOrDefaultAsync(m => m.SOURCE == id);
            if (qMQ_IN_HEADER == null)
            {
                return NotFound();
            }

            return View(qMQ_IN_HEADER);
        }

        // POST: QmqInHeader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var qMQ_IN_HEADER = await _context.QMQ_IN_HEADERs.FindAsync(id);
            _context.QMQ_IN_HEADERs.Remove(qMQ_IN_HEADER);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QMQ_IN_HEADERExists(string id)
        {
            return _context.QMQ_IN_HEADERs.Any(e => e.SOURCE == id);
        }
    }
}
