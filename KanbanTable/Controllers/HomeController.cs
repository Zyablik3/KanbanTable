using KanbanTable.Entities;
using KanbanTable.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KanbanTable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*
            var db = new Context();
            var tasks = db.KanbanTasks.ToList();

            var item = new KanbanTask() { Description = "description task", Name = "test task" };

            db.KanbanTasks.Add(item);

            db.SaveChanges();
            */

            // ошибка при добавлении. Есть мысли почему? потому что у меня связи сделаны неправильно? Они правильно сделаны Они обязательны так сказать у тЕбя
            // миграцию сделали и применили
            // запускаю тот же код
            // как будто работает
            // какой же я долбаеб:)
            // да не)) ни в коем случае)))) Ну не все сразу. Читай мануалы внимательней. Тут вникать надо. Тогда понимание придет со временем
            // если что обращайся
            // я пока отключаюсь. Спасибо большое, извиняюсь, что так много времени трачу вашего все ок

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
