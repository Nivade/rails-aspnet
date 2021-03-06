﻿using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Rails.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }
        
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [Display(Name = "IBAN")]
        public string Iban { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
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

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Entity<ApplicationUser>().ToTable("User", "DBI346087");
            modelBuilder.Entity<IdentityRole>().ToTable("Role", "DBI346087");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole", "DBI346087");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim", "DBI346087");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin", "DBI346087");

            
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Tram> Trams { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Connection> Connections { get; set; }
        //public DbSet<Maintenance> Schedules { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TramRoute> TramRoutes { get; set; }
        public DbSet<TramMaintenance> TramMaintenance { get; set; }


        public System.Data.Entity.DbSet<Rails.Models.RolePermission> RolePermissions { get; set; }

        public System.Data.Entity.DbSet<Rails.Models.TramType> TramTypes { get; set; }
    }
}