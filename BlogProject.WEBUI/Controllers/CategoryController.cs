using BlogProject.BLL;
using BlogProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.WEBUI.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryManager cm = new CategoryManager();
        // TEMPDATA ile Category Listeleme
        //public ActionResult Select(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    }
        //    //Category cat = cm.GetCategoryById((int)id);
        //    Category cat = cm.GetCategoryById(id.Value);

        //    if (cat == null)
        //    {
        //        return HttpNotFound();
        //    }


        //    TempData["mm"] = cat.Blogs;
        //    return RedirectToAction("Index","Home");
        //}
    }
}