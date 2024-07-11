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
	public class TaskKanbansController : Controller
	{
		Context db;
		public TaskKanbansController(Context context)
		{
			db = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await db.TaskKanbans.ToListAsync());
		}
		public IActionResult Create()
		{
            ViewBag.proect = new List<ProjectKanban>(db.ProjectKanbans.ToList());
            ViewBag.stat = new List<StatusTask>(db.TaskStatuses.ToList()); //выпадающий список

            return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(TaskKanban task)
		{
			db.TaskKanbans.Add(task);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id != null)
			{
				TaskKanban? task = await db.TaskKanbans.FirstOrDefaultAsync(p => p.Id == id);
				if (task != null)
				{
					db.TaskKanbans.Remove(task);
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
				TaskKanban? task = await db.TaskKanbans.FirstOrDefaultAsync(p => p.Id == id);
				if (task != null) return View(task);
			}
			return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> Edit(TaskKanban task)
		{
			db.TaskKanbans.Update(task);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

	}
}
