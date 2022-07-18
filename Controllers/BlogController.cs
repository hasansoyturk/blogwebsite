using Blog.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Blog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogrepository;
        private ICategoryRepository _categoryrepository;

        public BlogController(IBlogRepository _blogrepo,ICategoryRepository _categoryrepo)
        {
            _blogrepository = _blogrepo;
            _categoryrepository = _categoryrepo;    
        }

        public IActionResult Details(int id)
        {
            return View(_blogrepository.GetById(id));
        }

        public IActionResult Index(int? id)
        {
           var query = _blogrepository.GetAll().Where(i => i.IsApproved);

            if (id != null)
            {
                query = query.Where(i => i.CategoryId == id).OrderByDescending(i=>i.Date);    

              
            }
            
            return View(query.OrderByDescending(i=>i.Date)); 
        }

        public IActionResult List()
        {
            return View(_blogrepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryrepository.GetAll(),"CategoryId","Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Entity.Blog entity)
        {
            entity.Date = System.DateTime.Now;
            if(ModelState.IsValid)
            {
                _blogrepository.AddBlog(entity);
                return RedirectToAction("List");
            }

            return View(entity);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_categoryrepository.GetAll(), "CategoryId", "Name");
            return View(_blogrepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Entity.Blog entity)
        {
           
            if (ModelState.IsValid)
            {
                _blogrepository.UpdateBlog(entity);
                TempData["message"] = $"{entity.Title} Güncellendi.";
                return RedirectToAction("List");
                 
            }
            ViewBag.Categories = new SelectList(_categoryrepository.GetAll(), "CategoryId", "Name");
            return View(entity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {


            return View(_blogrepository.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int BlogId)
        {
            _blogrepository.DeleteBlog(BlogId);
            TempData["message"] = $"{BlogId} numaralı kayıt silindi.";
            return RedirectToAction("List");

        }

    }
}
