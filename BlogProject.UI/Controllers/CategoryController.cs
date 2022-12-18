using BlogProject.BLL;
using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        #region TempData ile Category Listeleme
        //public ActionResult Select(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    CategoryManager cm = new CategoryManager();
        //    Category cat = cm.GetCategoryById(id.Value);

        //    if (cat == null)
        //    {
        //        return HttpNotFound();
        //        //return RedirectToAction("Index", "Home");
        //    }

        //    TempData["blogs"] = cat.Blogs;

        //    return RedirectToAction("Index", "Home");
        //}
        #endregion



    }
}