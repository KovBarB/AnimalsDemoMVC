using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NewAnimalSearch.Models
{
    //:DbContext
    public class AnimalSearchDB : IdentityDbContext<ApplicationUser> 
    {
        public AnimalSearchDB()
            : base("name=AnimalSearchDB", throwIfV1Schema: false)
        {
           
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public static AnimalSearchDB Create()
        {
            // Remove default initializer
            //Database.SetInitializer<AnimalSearchDB>(null);
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;

            //DROP DB for testing
            //comment out!!
            //Database.SetInitializer<AnimalSearchDB>(new DropCreateDatabaseIfModelChanges<AnimalSearchDB>());

            //INIT
            //Database.SetInitializer<AnimalSearchDB>(new DBInit());

            return new AnimalSearchDB();
        }
    } 
}