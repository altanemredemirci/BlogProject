using BlogProject.BLL.Abstract;
using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL
{
    public class CategoryManager:ManagerBase<Category>
    {
        public override int Delete(Category cat)
        {
            //Category category = this.ListQueryable()
            //                        .Include("Blogs")
            //                        .ThenInclude("Likes")
            //                        .ThenInclude("Comments")
            //                        .FirstOrDefault(x => x.Id == item.Id);

            BlogManager blogManager = new BlogManager();
            LikeManager likeManager = new LikeManager();
            CommentManager commentManager = new CommentManager();

            // Kategori altındaki blog yazıları sırası ile silinmelidir.
            foreach (Blog blog in cat.Blogs.ToList())
            {

                //Blog blog = blogManager.ListQueryable().Include("Comments").Include("Likes").FirstOrDefault(x => x.Id == item.Id);

                // Blog silinmeden altındaki yorumlar silinmelidir.
                foreach (Comment comment in blog.Comments.ToList())
                {
                    commentManager.Delete(comment);
                }

                // Blog silinmeden altındaki likelar silinmelidir.
                foreach (Liked like in blog.Likes.ToList())
                {
                    likeManager.Delete(like);
                }

                blogManager.Delete(blog);
            }
            return base.Delete(cat);
        }
    }
}
