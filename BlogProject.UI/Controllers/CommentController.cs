using BlogProject.BLL;
using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.UI.Controllers
{
    public class CommentController : Controller
    {
        private BlogManager blogManager = new BlogManager();
        // GET: Comment
        public ActionResult ShowBlogComments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Blog blog = blogManager.ListQueryable().Include("Comments").FirstOrDefault(x => x.Id == id);

            if (blog == null)
            {
                return HttpNotFound();
            }


            return PartialView("_PartialComments",blog.Comments);
        }
    }
}