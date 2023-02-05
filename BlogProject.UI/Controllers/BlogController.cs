using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogProject.BLL;
using BlogProject.Entity;
using BlogProject.UI.Models;

namespace BlogProject.UI.Controllers
{
    public class BlogController : Controller
    {
        private BlogManager blogManager = new BlogManager();
        private CategoryManager categoryManager = new CategoryManager();
        private LikeManager likeManager=new LikeManager();  

        // GET: Blog
        public ActionResult Index()
        {
            var blogs = blogManager.ListQueryable().Include("Category").Where(
                    b => b.Owner.Id == CurrentSession.User.Id).OrderByDescending(
                    b => b.ModifiedOn);

            return View(blogs.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogManager.Find(b=> b.Id==id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }


        public ActionResult MyLikeBlogs()
        {
            var blogs = likeManager.ListQueryable().Include("LikedUser").Include("Blog").Where(
                x => x.LikedUser.Id == CurrentSession.User.Id).Select(
                x => x.Blog).Include("Category").Include("Owner").OrderByDescending(
                x => x.ModifiedOn);



            return View("Index",blogs.ToList());
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryManager.List(), "Id", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                blog.Owner = CurrentSession.User;
                blogManager.Insert(blog);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(categoryManager.List(), "Id", "Title", blog.CategoryId);
            return View(blog);
        }

        //// GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogManager.Find(x=> x.Id==id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(categoryManager.List(), "Id", "Title", blog.CategoryId);
            return View(blog);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                var b = blogManager.Find(x=> x.Id== blog.Id);
                b.IsDraft = blog.IsDraft;
                b.CategoryId=blog.CategoryId;
                b.Text=blog.Text;
                b.Title=blog.Title;

                blogManager.Update(b);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(categoryManager.List(), "Id", "Title", blog.CategoryId);
            return View(blog);
        }

        //// GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogManager.Find(x => x.Id == id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = blogManager.Find(x => x.Id == id);
            blogManager.Delete(blog);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetLiked(int[] ids)
        {
            if (CurrentSession.User != null)
            {
                List<int> likedBlogIds = likeManager.List(
                x => x.LikedUser.Id == CurrentSession.User.Id && ids.Contains(x.Blog.Id)).Select(
                x => x.Blog.Id).ToList();

                return Json(new { result = likedBlogIds });
            }
            return Json(new { result = false });
        } 
    }
}
