using BlogProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        #region Connection Optional


        //public DatabaseContext():base("Server=DESKTOP-9IJKPL9\\SQLDERS; Database=BlogProject;uid=sa;pwd=1")
        //{

        //}

        //public DatabaseContext()
        //{
        //    Database.Connection.ConnectionString = "Server=DESKTOP-9IJKPL9\\SQLDERS; Database=BlogProject;uid=sa;pwd=1";
        //}

        #endregion

        public DatabaseContext():base("MSSQL")
        {
            Database.SetInitializer(new MyInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
