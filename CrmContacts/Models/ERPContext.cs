using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERP.Models
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

        public virtual DbSet<Addlineitem> Addlineitems { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Deal> Deals { get; set; } = null!;
        public virtual DbSet<Dealowner> Dealowners { get; set; } = null!;
        public virtual DbSet<Dealstage> Dealstages { get; set; } = null!;
        public virtual DbSet<Dealtype> Dealtypes { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Industry> Industries { get; set; } = null!;
        public virtual DbSet<Lead> Leads { get; set; } = null!;
        public virtual DbSet<LeadSource> LeadSources { get; set; } = null!;
        public virtual DbSet<LeadStatus> LeadStatuses { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Pipeline> Pipelines { get; set; } = null!;
        public virtual DbSet<Priority> Priorities { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Timezone> Timezones { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CORTRACKER;Initial Catalog=ERP;User Id=sa;Password=123456;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addlineitem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Addlineitem", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("City", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Companies", "Crm");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnnualRevenue).HasColumnName("annual_revenue");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.CompanyOwner)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("company_owner");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Discription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("discription");

                entity.Property(e => e.IndustryType).HasColumnName("industryType");

                entity.Property(e => e.LinkedinCompanyPage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("linkedin_company_page");

                entity.Property(e => e.NumberOfEmplyees).HasColumnName("number_of_emplyees");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.RegionState).HasColumnName("region_state");

                entity.Property(e => e.TimeZone).HasColumnName("time_zone");

                entity.Property(e => e.Type)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact", "Crm");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("companyName");

                entity.Property(e => e.ContactOwner)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("contactOwner");

                entity.Property(e => e.CountryRegion).HasColumnName("country_Region");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Industry).HasColumnName("industry");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("jobTitle");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.LeadStatus).HasColumnName("leadStatus");

                entity.Property(e => e.LifeCycleStage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("lifeCycleStage");

                entity.Property(e => e.MobilePhoneNumber).HasColumnName("mobile_PhoneNumber");

                entity.Property(e => e.NumberOfEmployees).HasColumnName("number_ofEmployees");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.PoastalCode).HasColumnName("poastal_Code");

                entity.Property(e => e.StateRegion).HasColumnName("state_Region");

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(200)
                    .HasColumnName("streetAddress");

                entity.Property(e => e.TimeZone).HasColumnName("timeZone");

                entity.Property(e => e.WhatAppPhoneNumber).HasColumnName("whatApp_PhoneNumber");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Country", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.ToTable("Deals", "Crm");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Closedate).HasColumnType("datetime");

                entity.Property(e => e.Dealname)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dealowner>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Dealowner", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<Dealstage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Dealstage", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<Dealtype>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Dealtype", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("department", "Hrm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
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

                entity.Property(e => e.Department).HasColumnName("department");

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

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("date")
                    .HasColumnName("joiningDate");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.PinCode).HasColumnName("pinCode");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("gender", "Hrm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Industry", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("Leads", "Crm");

                entity.Property(e => e.AnnualRevenue).HasColumnName("annualRevenue");

                entity.Property(e => e.Company)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("company");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailOutput)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("emailOutput");

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Industry).HasColumnName("industry");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.LeadOwner).HasColumnName("leadOwner");

                entity.Property(e => e.LeadSource).HasColumnName("leadSource");

                entity.Property(e => e.LeadStatus).HasColumnName("leadStatus");

                entity.Property(e => e.Mobile).HasColumnName("mobile");

                entity.Property(e => e.NumberOfEmployees).HasColumnName("numberOfEmployees");

                entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.SecondaryEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("secondaryEmail");

                entity.Property(e => e.SkypeId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("skypeId");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Twitter)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("twitter");

                entity.Property(e => e.Website)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("website");
            });

            modelBuilder.Entity<LeadSource>(entity =>
            {
                entity.ToTable("leadSource", "Crm");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");
            });

            modelBuilder.Entity<LeadStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("leadStatus", "Crm");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("location", "Hrm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<Pipeline>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Pipeline", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Priority", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("State", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<Timezone>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Timezone", "Crm");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "login");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
