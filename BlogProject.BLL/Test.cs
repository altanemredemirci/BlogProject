using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogProject.BLL
{
    public class Test
    {
        Repository<User> repo_user = new Repository<User>();
        Repository<Comment> repo_comment = new Repository<Comment>();
        Repository<Blog> repo_blog = new Repository<Blog>();
        public Test()
        {
           
        }
        public void InsertTest()
        {       
            #region 1.Yöntem
            //User u = new User();
            //u.Name = "Kıvanç";
            //u.Surname = "Demirci";
            //u.Email = "kivanc@gmail.com";
            //u.ActivateGuid = Guid.NewGuid();
            //u.IsActive = true;
            //u.IsAdmin = false;
            //u.Username = "kivanc";
            //u.Password = "1";
            //u.CreateOn = DateTime.Now;
            //u.ModifiedOn = DateTime.Now.AddMinutes(5);
            //u.ModifiedUsername = "altanemre";

            //repo_user.Insert(u);
            #endregion

            int result = repo_user.Insert(new User()
            {
                Name = "aaa",
                Surname = "bbb",
                Email = "aaa@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "aaa",
                Password = "1",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "aaa"
            });

        }

        public void UpdateTest()
        {
            User user = repo_user.Find(x => x.Username == "aaa");

            if(user != null)
            {
                user.Username = "xxx";
                int result = repo_user.Update(user);
            }
        }

        public void CommentTest()
        {
            User user = repo_user.Find(i => i.Id == 1);

            Blog blog = repo_blog.Find(i => i.Id == 3);

            Comment comment = new Comment()
            {
                Text = "Bu bir test'dir.",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "altanemre",
                Blog = blog,
                Owner = user
            };

            repo_comment.Insert(comment);
        }
    }
}
