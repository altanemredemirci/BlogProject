using BlogProject.BLL;
using BlogProject.Entities;
using BlogProject.Entities.Messages;
using BlogProject.Entities.ValueObjects;
using BlogProject.WEBUI.ViewModels;
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
        private UserManager um = new UserManager();
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

            if (ModelState.IsValid)
            {
                BusinessLayerResult<User> res = um.LoginUser(model);

                if (res.Errors.Count > 0)
                {
                    if(res.Errors.Find(x=> x.Code == ErrorMessageCode.UserIsNotActive) != null)
                    {
                        ViewBag.SetLink = "http://Home/UserActivate";
                    }

                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }

                Session["login"] = res.Result;    // Session'a kullanıcı ekleme
                return RedirectToAction("Index"); // yönlendirme...
            }

            return View(model);
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
               
                BusinessLayerResult<User> res = um.RegisterUser(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }

                OkViewModel notifyModel = new OkViewModel()
                {
                    Title = "Kayıt Başarılı",
                    RedirectingUrl = "/Home/Login"
                };

                notifyModel.Items.Add("Lütfen email adresinize gönderilen aktivasyon linkine tıklayarak hesabınızı aktifleştiriniz. Hesabınızı aktifleştirmeden blog yazmaz ve beğeni yapamazsınız.");

                return View("OK", notifyModel);
            }
           
            return View(model);
        } 

        public ActionResult UserActivate(Guid id)
        {
            BusinessLayerResult<User> res = um.ActivateUser(id);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel notifyModel = new ErrorViewModel()
                {
                    Title = "Geçersiz İşlem",
                    Items=res.Errors
                };

                return View("Error", notifyModel);
            }
            OkViewModel okModel = new OkViewModel()
            {
                Title = "Hesap Aktifleştirildi",
                RedirectingUrl = "/Home/Login"
            };

            okModel.Items.Add("Hesabınız aktifleştirilmiştir. Artık blog yazabilir vey beğeni yapabilirsiniz");
            return View("OK", okModel);
        }
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index");
        }

        public ActionResult ShowProfile()
        {
            User currentUser = Session["login"] as User;

            BusinessLayerResult<User> res = um.GetUserById(currentUser.Id);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel notifyModel = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors
                };
                return View("Error", notifyModel);
            }

            return View(res.Result);
        }

        public ActionResult EditProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            return View();
        }

        public ActionResult DeleteProfile()
        {
            return View();
        }
    }
}