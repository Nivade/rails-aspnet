using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Rails.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Required]
        public int FunctieId { get; set; }

        public virtual Functie Functie { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("OracleDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        /// <summary>
        /// Maps table names, and sets up relationships between the various user entities
        /// </summary>
        /// <param name="modelBuilder"/>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("DBI346087");

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers", "DBI346087");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles", "DBI346087");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles", "DBI346087");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims", "DBI346087");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins", "DBI346087");
        }

        public DbSet<Functie> Functies { get; set; }

    }
}