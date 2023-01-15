using BlogProject.DAL.EF;
using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL
{
    public class BlogManager
    {
        private Repository<Blog> repo_blog = new Repository<Blog>();
        public List<Blog> GetAllBlog()
        {           
            return repo_blog.List();            
        }
        public IQueryable<Blog> GetAllBlogQueryable()
        {
            var blogs = repo_blog.ListQueryable(); // blogs => db.Blogs.AsQueryable().Include("Owner").To
            return blogs.Include("Owner");
        }
    }
}
