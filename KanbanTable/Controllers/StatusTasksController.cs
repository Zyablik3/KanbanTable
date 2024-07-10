using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KanbanTable.Entities;

namespace KanbanTable.Controllers
{
    public class StatusTasksController : Controller
    {
        private readonly Context _context;

        public StatusTasksController(Context context)
        {
            _context = context;
        }

        // GET: StatusTasks
        public async Task<IActionResult> Index()
        {
              return _context.TaskStatuses != null ? 
                          View(await _context.TaskStatuses.ToListAsync()) :
                          Problem("Entity set 'Context.TaskStatuses'  is null.");
        }

        // GET: StatusTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TaskStatuses == null)
            {
                return NotFound();
            }

            var statusTask = await _context.TaskStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusTask == null)
            {
                return NotFound();
            }

            return View(statusTask);
        }

        // GET: StatusTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StatusTask statusTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusTask);
        }

        // GET: StatusTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TaskStatuses == null)
            {
                return NotFound();
            }

            var statusTask = await _context.TaskStatuses.FindAsync(id);
            if (statusTask == null)
            {
                return NotFound();
            }
            return View(statusTask);
        }

        // POST: StatusTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StatusTask statusTask)
        {
            if (id != statusTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusTaskExists(statusTask.Id))
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
            return View(statusTask);
        }

        // GET: StatusTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TaskStatuses == null)
            {
                return NotFound();
            }

            var statusTask = await _context.TaskStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusTask == null)
            {
                return NotFound();
            }

            return View(statusTask);
        }

        // POST: StatusTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TaskStatuses == null)
            {
                return Problem("Entity set 'Context.TaskStatuses'  is null.");
            }
            var statusTask = await _context.TaskStatuses.FindAsync(id);
            if (statusTask != null)
            {
                _context.TaskStatuses.Remove(statusTask);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusTaskExists(int id)
        {
          return (_context.TaskStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
