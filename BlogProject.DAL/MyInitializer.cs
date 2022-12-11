using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL
{
    internal class MyInitializer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            // Adding Admin User...
            User admin = new User()
            {
                Name="Altan Emre",
                Surname="Demirci",
                Email="altanemre1989@gmail.com",
                ActivateGuid=Guid.NewGuid(),
                IsActive=true,
                IsAdmin=true,
                Username="altanemre",
                Password="123456",
                CreateOn=DateTime.Now,
                ModifiedOn=DateTime.Now.AddMinutes(5),
                ModifiedUsername="altanemre"
            };

            // Adding standart user...
            User standartUser = new User()
            {
                Name = "Kıvanç",
                Surname = "Demirci",
                Email = "kivanc@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "kivanc",
                Password = "1",
                CreateOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "altanemre"
            };

            context.Users.Add(admin);
            context.Users.Add(standartUser);

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
                    Password = "1",
                    CreateOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{i}"
                };

                context.Users.Add(user);
            }
            context.SaveChanges();

            List<User> userList = context.Users.ToList();
            // Adding fake categories

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

                // Adding fake blogs

                for (int k = 0; k < FakeData.NumberData.GetNumber(5,9); k++)
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

                    // Adding fake comments
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3,5); j++)
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

                    // Adding fake likes

                  

                    for (int m = 0; m < blog.LikeCount; m++)
                    {
                        Liked like = new Liked()
                        {
                            LikedUser = userList[m]
                        };

                        blog.Likes.Add(like);
                    }
                }

            }

            context.SaveChanges();

        }
    }
}
