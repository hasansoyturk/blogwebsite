using Blog.Data.Abstract;
using Blog.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Controllers
{
    public class CategoryController : Controller
    {

        private ICategoryRepository repository;

        public CategoryController(ICategoryRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(repository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category entity)
        {
            if (ModelState.IsValid)
            {
                repository.AddCategory(entity);
                return RedirectToAction("List");
            }


            return View(entity);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Category entity)
        {
            if (ModelState.IsValid)
            {

                repository.UpdateCategory(entity);
                TempData["message"] = $"{entity.Name} Güncellendi.";
                return RedirectToAction("List");
            }

            return View();

        }

    }
}
