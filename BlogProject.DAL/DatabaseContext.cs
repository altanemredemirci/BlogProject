using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("MSSQL")
        {
            Database.SetInitializer(new MyInitializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //FluentAPI

            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Comments)
                .WithRequired(c => c.Blog)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Likes)
                .WithRequired(c => c.Blog)
                .WillCascadeOnDelete(true);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Liked> Likes { get; set; }

    }
}
