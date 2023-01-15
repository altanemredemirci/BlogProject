using BlogProject.BLL;
using BlogProject.Entity.ViewModels;
using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogProject.Entity.Messages;
using BlogProject.UI.ViewModels;

namespace BlogProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private BlogManager bm = new BlogManager();
        private CategoryManager cm = new CategoryManager();
        private UserManager um = new UserManager();
        // GET: Home
        public ActionResult Index()
        {           
            return View(bm.GetAllBlogQueryable().OrderByDescending(i => i.ModifiedOn).ToList());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                       
            Category cat = cm.GetCategoryById(id.Value);

            if (cat == null)
            {
                return HttpNotFound();                
            }                      

            return View("Index",cat.Blogs.OrderByDescending(i=> i.ModifiedOn).ToList());
        }

        public ActionResult MostLiked()
        {
            return View("Index",bm.GetAllBlogQueryable().OrderByDescending(i => i.LikeCount).ToList());
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
            if (ModelState.IsValid)
            {
                BusinessLayerResult<User> res = um.LoginUser(model);

                if (res.Errors.Count > 0)
                {
                    if(res.Errors.Find(x=> x.Code == ErrorMessageCode.UserIsNotActive) != null)
                    {
                        ViewBag.SetLink = "http://localhost:64755/home/Activate/1234-5678-9999";
                    }

                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }

                Session["login"] = res.Result;    // Session'da kullanıcı bilgisi saklama..
                return RedirectToAction("Index"); // yönlendirme

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
         

            if(ModelState.IsValid) //ModelState.isValid => Model attribute leri sağlanıyor mu?
            {
                #region Username ve Email Kontrol
                //if (model.Username == "altanemre")
                //{
                //    ModelState.AddModelError("Username", "Kullanıcı adı kullanılıyor");
                //}

                //if (model.Username == "altanemre@gmail.com")
                //{
                //    ModelState.AddModelError("", "Email adresi kullanılıyor");
                //}

                //foreach(var item in ModelState)
                //{
                //    if (item.Value.Errors.Count > 0)
                //    {
                //        return View(model);
                //    }
                //}
                #endregion

                BusinessLayerResult<User> res = um.RegisterUser(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(model);
                }

                OkViewModel notifyObj = new OkViewModel()
                {
                    Title = "Kayıt Başarılı",
                    RedirectingUrl = "/Home/Login"
                };

                notifyObj.Items.Add("Lütfen e-mail adresinize gönderilen aktivasyon mailindeki linke tıklayarak üyeliğinizi aktifleşitiriniz.");

                return View("Ok", notifyObj);
            }

            return View(model);
        }
            
        public ActionResult UserActivate(Guid id)
        {
            // Kullanıcı aktivasyonu sağlanacak
            BusinessLayerResult<User> res = um.ActivateUser(id);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel errorObj = new ErrorViewModel()
                {
                    Items = res.Errors
                };                

                return View("Error", errorObj);
            }

            OkViewModel notifyObj = new OkViewModel()
            {
                Title = "Hesap Aktifleştirildi",
                RedirectingUrl = "/Home/Login"
            };

            notifyObj.Items.Add("Hesabınız aktifleştirildi. Blog yazabilir ve yorum, like yapabilirsiniz.");

            return View("Ok", notifyObj);
        }
           

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult ShowProfile()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("login");
            }
            User currentUser = Session["login"] as User;

            //BusinessLayerResult<User> res = um.GeUserById(currentUser.Id);

            //if (res.Errors.Count > 0)
            //{
            //    // TODO : Kullanıcıyı bir hata ekranına yönlendirelim
            //}

            //return View(res.Result);

            return View(currentUser);
        }

        public ActionResult EditProfile()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("login");
            }

            User currentUser = Session["login"] as User;


            return View(currentUser);
        }

        [HttpPost]
        public ActionResult EditProfile(User model, HttpPostedFileBase ProfileImage)
        {
            if(ProfileImage != null &&
                (ProfileImage.ContentType=="image/jpeg" ||
                ProfileImage.ContentType == "image/jpg" ||
                ProfileImage.ContentType == "image/png"))
            {
                string filename = $"user{model.Id}.{ProfileImage.ContentType.Split('/')[1]}";

                ProfileImage.SaveAs(Server.MapPath($"~/Content/img/{filename}"));
                model.ProfileImageFilename = filename;
            }

            BusinessLayerResult<User> res = um.UpdateProfile(model);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel errorObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title="Profil Güncellenemedi",
                    RedirectingUrl="/Home/EditProfile"
                };

                return View("Error", errorObj);
            }

            Session["login"] = res.Result; //Profil güncellendiği için session güncellendi.

            return RedirectToAction("ShowProfile");
        }

        public ActionResult DeleteProfile()
        {
            return View();
        }
    }
}