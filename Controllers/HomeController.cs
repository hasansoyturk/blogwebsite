using Blog.Data.Abstract;
using Blog.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        

        private IBlogRepository blogRepository;

        public HomeController(IBlogRepository repository)
        {
            blogRepository = repository;
        }
   
        public IActionResult Index()
        {
            return View(blogRepository.GetAll().Where(i=>i.IsApproved && i.IsHome));
        }
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

    }
}
