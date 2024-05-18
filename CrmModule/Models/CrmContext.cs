using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrmModule.Models;

public partial class CrmContext : DbContext
{
    public CrmContext()
    {
    }

    public CrmContext(DbContextOptions<CrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=CORTRACKER;Initial Catalog=ERP;User Id=sa;Password=123456;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("companies");

            entity.Property(e => e.Id).HasColumnName("ID");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
