using KotoCulator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotoCulator.Database
{
    //Singleton
    public class LocalDBContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<Creation> Creations { get; set; }

        private static readonly LocalDBContext _instance = new LocalDBContext();

        public static LocalDBContext GetInstance()
        {
            return _instance;
        }

        private LocalDBContext() : base()
        {
            Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());
            Database.EnsureCreated();
            FillDataBase();
        }

        private void FillDataBase() 
        { 
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialConsumption>();
        }
    }
}
