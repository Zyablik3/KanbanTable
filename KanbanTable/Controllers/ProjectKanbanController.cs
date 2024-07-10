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
	public class ProjectKanbanController : Controller
	{
		Context db;
		public ProjectKanbanController(Context context)
		{
			db = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await db.ProjectKanbans.ToListAsync());
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(ProjectKanban project)
		{
			db.ProjectKanbans.Add(project);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id != null)
			{
				ProjectKanban? project = await db.ProjectKanbans.FirstOrDefaultAsync(p => p.Id == id);
				if (project != null)
				{
					db.ProjectKanbans.Remove(project);
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
				ProjectKanban? project = await db.ProjectKanbans.FirstOrDefaultAsync(p => p.Id == id);
				if (project != null) return View(project);
			}
			return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> Edit(ProjectKanban project)
		{
			db.ProjectKanbans.Update(project);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

	}
}