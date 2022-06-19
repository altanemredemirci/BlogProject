using BlogProject.BLL;
using BlogProject.Entities;
using BlogProject.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private BlogManager bm = new BlogManager();
        // GET: Home
        public ActionResult Index()
        {
            //CategoryController üzerinden gelen view talebi ve model
            //if (TempData["mm"] != null)
            //{
            //    return View(TempData["mm"] as List<Blog>);
            //}           

            return View(bm.GetAllBlog().OrderByDescending(x=> x.ModifiedOn).ToList());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            CategoryManager cm = new CategoryManager();
            Category cat = cm.GetCategoryById(id.Value);

            if (cat == null)
            {
                return HttpNotFound();
            }

            return View("Index", cat.Blogs.OrderByDescending(x=> x.ModifiedOn).ToList());
          
        }

        public ActionResult MostLiked()
        {
            return View("Index", bm.GetAllBlog().OrderByDescending(x => x.LikeCount).ToList());
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {        
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            // Giriş Kontrolü ve yönlendirme
            // Session'a kullanıcı bilgisi ekleme
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserManager um = new UserManager();
                BusinessLayerResult<User> res = um.RegisterUser(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }
                return RedirectToAction("RegisterOk");
            }
           
            return View(model);
        }

        public ActionResult RegisterOk()
        {
            return View();
        }

        public ActionResult UserActivate(Guid activate_id)
        {
            //Kullanıcı aktivasyonu sağlanacak...
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}