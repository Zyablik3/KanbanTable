using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KanbanTable.Entities;
using KanbanTable;

namespace Entities.Controllers
{
    public class CustomersController : Controller
    {
        Context db;
        public  CustomersController(Context context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Customers.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            db.Customers.Add(customer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Customer? customer = await db.Customers.FirstOrDefaultAsync(p => p.Id == id);
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Customer? customer = await db.Customers.FirstOrDefaultAsync(p => p.Id == id);
                if (customer != null) return View(customer);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            db.Customers.Update(customer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}