using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrmContacts.Models
{
    public partial class ARBAAZContext : DbContext
    {
        public ARBAAZContext()
        {
        }

        public ARBAAZContext(DbContextOptions<ARBAAZContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactDetail> Contact { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=CORTRACKER;Initial Catalog=ERP;User Id=sa;Password=123456;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactDetail>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ContactOwner)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CountryRegion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Country_Region");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Industry)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LeadStatus)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LifeCycleStage)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhoneNumber).HasColumnName("Mobile_PhoneNumber");

                entity.Property(e => e.NumberOfEmployees).HasColumnName("Number_ofEmployees");

                entity.Property(e => e.PoastalCode).HasColumnName("Poastal_code");

                entity.Property(e => e.StateRegion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("State_Region");

                entity.Property(e => e.StreetAddress).HasMaxLength(200);

                entity.Property(e => e.TimeZone).HasMaxLength(200);

                entity.Property(e => e.WhatAppPhoneNumber).HasColumnName("WhatApp_PhoneNumber");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.BatchNo).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Manufacturer).HasMaxLength(100);

                entity.Property(e => e.Mrp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("MRP");

                entity.Property(e => e.ProductCode).HasMaxLength(30);

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.ShippingNo).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
