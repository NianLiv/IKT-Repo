using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                //Create and save a new Organization.
                Console.Write("Enter a name for at new Organization: ");
                var organizationName = Console.ReadLine();

                var organization = new Organization { OrganizationName = organizationName };
                db.Organizations.Add(organization);
                db.SaveChanges();

                // Create and save a new User with the above organization.
                Console.Write("Enter er name for a new User: ");
                var userName = Console.ReadLine();

                var user = new User { Username = userName, Organization = organization };
                db.Users.Add(user);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Blogs
                    orderby b.Name
                    select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                var query2 = from u in db.Users
                    orderby u.Username
                    select u;

                Console.WriteLine("All Users and Organizations in database:");
                foreach (var item in query2)
                {
                    Console.WriteLine(item.Username);
                    Console.WriteLine(item.Organization.OrganizationName);
                }

                Console.ReadKey();
            }
        }
    }

    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }

        public virtual Organization Organization { get; set; }
    }

    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }

        public virtual List<Country> Homelands { get; set; }
    }

    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CountryCode { get; set; }

        public virtual List<Organization> OrgsInCounty { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display_name");
        }
    }
}