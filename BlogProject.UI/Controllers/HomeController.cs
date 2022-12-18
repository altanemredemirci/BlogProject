using BlogProject.BLL;
using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (TempData["blogs"] != null)
            {
                return View(TempData["blogs"] as List<Blog>);
            }
            
            BlogManager bm = new BlogManager();
            List<Blog> model = bm.GetAllBlog();
            return View(model);
        }
    }
}