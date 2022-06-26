using BlogProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.EntityFramework
{
    internal class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Adding adminUser...
            User admin = new User()
            {
                Name = "Altan Emre",
                Surname = "Demirci",
                Email = "altanemredemirci@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "altanemre",
                Password = "1",
                ProfileImageFileName="user.png",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "altanemre"
            };

            //Adding standart user...
            User standartUser = new User()
            {
                Name = "Uras",
                Surname = "Demirci",
                Email = "urasdemirci@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "altanuras",
                Password = "1",
                ProfileImageFileName = "user.png",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "altanemre"
            };
            context.Users.Add(admin);
            context.Users.Add(standartUser);

            //Adding fakeUser..
            for (int i = 0; i < 8; i++)
            {
                User user = new User()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    Username = $"user{i}",
                    Password = "123",
                    ProfileImageFileName = "user.png",
                    CreateOn = DateTime.Now,
                    ModifiedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = $"user{i}"
                };
                context.Users.Add(user);
            }

            context.SaveChanges();

            //user list for using
            List<User> userList = context.Users.ToList();

            // Adding fake Categories...
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreateOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "altanemre"
                };

                context.Categories.Add(cat);

                // Adding fake Blogs
                for (int j = 0; j < FakeData.NumberData.GetNumber(5, 9); j++)
                {
                    User owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                    Blog blog = new Blog()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = owner,
                        CreateOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = owner.Username
                    };
                    cat.Blogs.Add(blog);

                    //Adding fake comments
                    for (int k = 0; k < FakeData.NumberData.GetNumber(3, 5); k++)
                    {
                        User comment_owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = comment_owner,
                            CreateOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = comment_owner.Username
                        };

                        blog.Comments.Add(comment);
                    }

                    //Adding fake like..
                   
                    for (int m = 0; m < blog.LikeCount; m++)
                    {
                        Like liked = new Like()
                        {
                            LikedUser = userList[m]
                        };
                        blog.Likes.Add(liked);
                    }

                }
            }

            context.SaveChanges();
        }
    }
}
