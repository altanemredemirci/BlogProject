using BlogProject.DAL;
using BlogProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL
{
    public class Test
    {
        private Repository<Category> repo_category = new Repository<Category>();
        private Repository<User> repo_user = new Repository<User>();
        public Test()
        {
            
            List<Category> liste = repo_category.List(x => x.Id > 5);
        }

        public void InsertTest()
        {            
            int result = repo_user.Insert(new User()
            {
                Name = "aaa",
                Surname = "bbb",
                Email = "aabb@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "aabb",
                Password = "111",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "aabb"
            });
        }

        public void UpdateTest()
        {
            User user = repo_user.Find(x => x.Username == "aabb");

            if (user != null)
            {
                user.Username = "xxx";
                int result = repo_user.Update();
            }
        }

        public void DeleteTest()
        {
            User user = repo_user.Find(x => x.Username == "xxx");

            if (user != null)
            {
                int result = repo_user.Delete(user);
            }
        }
    }
}
