using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectApiCompanyCTECH.MainEntitites.EntityConfigurations;
using System.IO;
using System.Reflection;
using System;
using ProjectApiCompanyCTECH.Model;

namespace ProjectApiCompanyCTECH.Entities
{
    public class SdkEntities : DbContext
    {

        public SdkEntities()
        {
        }

        public SdkEntities(DbContextOptions options) : base(options)
        {
        }

        public SdkEntities(DbContextOptions<SdkEntities> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Prepare configuration builder
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile($"appsettings.json", optional: false)
               .Build();
            //Bind your custom settings class instance to values from appsettings.json
            var dbSetting = configuration.GetSection("ConnectionStrings").GetConnectionString("MainDb");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(dbSetting);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure using Fluent api

            modelBuilder.ApplyConfiguration(new EmployeesEntityMapper());

            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.BaseType != null && t.BaseType.IsGenericType &&
                                   (t.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityMapper<>)
                                   || t.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityMapperClass<>)));
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.BaseType != null && t.BaseType.IsGenericType &&
                                   (t.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityMapperClassBase<,>)));
        }
    }
}
