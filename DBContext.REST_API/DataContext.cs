using Entities.REST_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Common.REST_API;
using System;

namespace DBContext.REST_API
{
    public class DataContext : DbContext
    {
        public DbSet<ProductMaster> ProductMaster { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        

        private readonly IOptions<AppSettings> _settings;

        public DataContext(DbContextOptions<DataContext> contextOptions,
            IOptions<AppSettings> settings) : base(contextOptions)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Log the queries to console
            optionsBuilder.LogTo(Console.WriteLine);

            // connect to sqlite database
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlite(
                _settings.Value.ConnectionStrings.RestApiDatabase);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //The above line is not required

            //This will default the schema from dbo to defaultschema
            //modelBuilder.HasDefaultSchema("defaultschema");

            ///** Enums **/
            modelBuilder.Entity<ProductType>().HasData(Enumeration.GetAll<ProductType>());
            modelBuilder.Entity<ProcessorType>().HasData(Enumeration.GetAll<ProcessorType>());
            modelBuilder.Entity<FormFactor>().HasData(Enumeration.GetAll<FormFactor>());
            modelBuilder.Entity<Brand>().HasData(Enumeration.GetAll<Brand>());

            modelBuilder.Entity<PropertyType>().HasData(Enumeration.GetAll<PropertyType>());
            modelBuilder.Entity<LookupSource>().HasData(Enumeration.GetAll<LookupSource>());

            ///** Seed Product, ProductDesktop, ProductLaptop **/
            modelBuilder.Entity<ProductMaster>()
                .HasData(SeedData.ProductMasterList);

            modelBuilder.Entity<ProductDetail>()
                .HasData(SeedData.ProductDetailList);




        }
    }
}
