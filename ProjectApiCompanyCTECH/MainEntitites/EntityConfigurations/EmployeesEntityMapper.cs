using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectApiCompanyCTECH.Entities;
using ProjectApiCompanyCTECH.Model;
using System.Reflection.Emit;
using System;

namespace ProjectApiCompanyCTECH.MainEntitites.EntityConfigurations
{
    public class EmployeesEntityMapper : BaseEntityMapper<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.Property(e => e.Fullname).IsRequired().HasMaxLength(100).HasColumnName("fullname");
            builder.Property(e => e.Birthday).IsRequired().HasColumnName("birthday");
            builder.Property(e => e.Gender).IsRequired().HasColumnName("gender");
            builder.Property(e => e.Email).IsRequired().HasMaxLength(50).HasColumnName("email");
            builder.Property(e => e.PhoneNumber).HasMaxLength(10).HasColumnName("phone_number");
            builder.Property(e => e.Salary).IsRequired().HasColumnName("salary");
            builder.Property(e => e.Department).IsRequired().HasConversion<int>().HasColumnName("department");
            builder.Property(e => e.Image).HasColumnName("image");
            builder.Property(e => e.Biography).HasMaxLength(100).IsRequired().HasColumnName("biography");
            builder.Property(e => e.CreateDate).HasColumnName("create_date");
            builder.Property(e => e.ModifiedDate).HasColumnName("modified_date");
            

           

        }
    }
}
