using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrmContacts.Models
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=CORTRACKER;Initial Catalog=ERP;User Id=sa;Password=123456;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Companies", "Crm");

                entity.Property(e => e.AnnualRevenue).HasColumnName("annual_revenue");

                entity.Property(e => e.City)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.CompanyOwner)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("company_owner");

                entity.Property(e => e.Discription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("discription");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LinkedinCompanyPage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("linkedin_company_page");

                entity.Property(e => e.NumberOfEmplyees).HasColumnName("number_of_emplyees");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.RegionState)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("region_state");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("time_zone");

                entity.Property(e => e.Type)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact", "Crm");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("companyName");

                entity.Property(e => e.ContactOwner)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("contactOwner");

                entity.Property(e => e.CountryRegion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("country_Region");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Industry)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("industry");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("jobTitle");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.LeadStatus)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("leadStatus");

                entity.Property(e => e.LifeCycleStage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("lifeCycleStage");

                entity.Property(e => e.MobilePhoneNumber).HasColumnName("mobile_PhoneNumber");

                entity.Property(e => e.NumberOfEmployees).HasColumnName("number_ofEmployees");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.PoastalCode).HasColumnName("poastal_Code");

                entity.Property(e => e.StateRegion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("state_Region");

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(200)
                    .HasColumnName("streetAddress");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(200)
                    .HasColumnName("timeZone");

                entity.Property(e => e.WhatAppPhoneNumber).HasColumnName("whatApp_PhoneNumber");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees", "Hrm");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.Department)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("department");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("employeeName");

                entity.Property(e => e.EmployeeNo).HasColumnName("employeeNo");

                entity.Property(e => e.ExtensionNumber).HasColumnName("extensionNumber");

                entity.Property(e => e.Gender)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("date")
                    .HasColumnName("joiningDate");

                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.PinCode).HasColumnName("pinCode");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
