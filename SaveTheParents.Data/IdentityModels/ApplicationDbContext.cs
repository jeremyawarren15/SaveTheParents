using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SaveTheParents.Data.IdentityModels
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();
            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }
}