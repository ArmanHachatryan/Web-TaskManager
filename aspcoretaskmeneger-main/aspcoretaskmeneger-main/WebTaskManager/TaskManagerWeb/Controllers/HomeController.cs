using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagerWeb.Models;
using TaskManagerWeb.TaskService;

namespace TaskManagerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbStorage _storage;
        private readonly ChangeStatusService _changeStatus;
        private readonly CreateTaskService _createTask;

        public HomeController(DbStorage storage, ChangeStatusService changeStatus,
            CreateTaskService createTask)
        {
            _storage = storage;
            _changeStatus = changeStatus;
            _createTask = createTask;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_storage.Tasks.ToList());
        }
        [HttpPost]
        public IActionResult Index(string name)
        {
            _createTask.CreateTask(name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Change(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.TaskId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Change(int id, string status)
        {
            _changeStatus.ChangeStatus(id, status);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var task = _storage.Tasks.First(p => p.Id == id);
            _storage.Remove(task);
            _storage.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}