using BlogProject.DAL.EntityFramework;
using BlogProject.Entities;
using System;
using System.Collections.Generic;
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
            return repo_blog.ListQueryable();
        }
    }
}
