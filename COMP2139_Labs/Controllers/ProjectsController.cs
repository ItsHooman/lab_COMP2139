using Microsoft.AspNetCore.Mvc;
using COMP2139_Labs.Models;

namespace COMP2139_Labs.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            var projects = new List<Project>()
            {
                new Project { ProjectId = 1, Name = "Project 1", Description = "First Project" },
                new Project { ProjectId = 2, Name = "Project 2", Description = "Second Project" },
                new Project { ProjectId = 3, Name = "Project 3", Description = "Third Project" },
                new Project { ProjectId = 4, Name = "Project 4", Description = "Fourth Project" }


        };
            return View(projects);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public IActionResult Create(Project project)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            return View();
        }

    }
}
