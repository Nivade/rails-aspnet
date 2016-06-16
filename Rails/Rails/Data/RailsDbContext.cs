using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Rails.Models;
using Rails.Models.Domain;


namespace Rails.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class RailsDbContext : IdentityDbContext<ApplicationUser>
    {
        public RailsDbContext()
            : base("OracleDbContext", throwIfV1Schema: false)
        {
            
        }

        public static RailsDbContext Create()
        {
            return new RailsDbContext();
        }



        /// <summary>
        /// Maps table names, and sets up relationships between the various user entities
        /// </summary>
        /// <param name="builder"/>
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
            

            builder.HasDefaultSchema("DBI346087");

            builder.Entity<ApplicationUser>().ToTable("User", "DBI346087");
            builder.Entity<IdentityRole>().ToTable("Role", "DBI346087");
            builder.Entity<IdentityUserRole>().ToTable("UserRole", "DBI346087");
            builder.Entity<IdentityUserClaim>().ToTable("UserClaim", "DBI346087");
            builder.Entity<IdentityUserLogin>().ToTable("UserLogin", "DBI346087");
        }

        public DbSet<TramType> TramTypes { get; set; }
        public DbSet<Tram> Trams { get; set; }
        public DbSet<TramMaintenance> TramMaintenances { get; set; }
        public System.Data.Entity.DbSet<Rails.Models.Domain.Route> Routes { get; set; }
        public System.Data.Entity.DbSet<Rails.Models.Domain.TramRoute> TramRoutes { get; set; }
        public System.Data.Entity.DbSet<Rails.Models.Domain.Sector> Sectors { get; set; }
        public System.Data.Entity.DbSet<Rails.Models.Domain.Connection> Connections { get; set; }

        public System.Data.Entity.DbSet<Rails.Models.Domain.Track> Tracks { get; set; }
        public System.Data.Entity.DbSet<Rails.Models.Domain.Depot> Depots { get; set; }
    }
}