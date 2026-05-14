using System;
using System.Collections.Generic;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class AgroGuideMsContext : DbContext
{
    public AgroGuideMsContext()
    {
    }

    public AgroGuideMsContext(DbContextOptions<AgroGuideMsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Crop> Crops { get; set; }

    public virtual DbSet<CropDisease> CropDiseases { get; set; }

    public virtual DbSet<CropFertilizer> CropFertilizers { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Farmer> Farmers { get; set; }

    public virtual DbSet<Fertilizer> Fertilizers { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<SoilType> SoilTypes { get; set; }

    public virtual DbSet<WaterRequirement> WaterRequirements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Crop>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CropName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GrowthDurationDays)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ScientificName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Crops)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Crops_Categories");

            entity.HasOne(d => d.Season).WithMany(p => p.Crops)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Crops_Seasons");

            entity.HasOne(d => d.SoilType).WithMany(p => p.Crops)
                .HasForeignKey(d => d.SoilTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Crops_SoilTypes");

            entity.HasOne(d => d.WaterRequirement).WithMany(p => p.Crops)
                .HasForeignKey(d => d.WaterRequirementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Crops_WaterRequirements");
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.Property(e => e.Causes)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DiseaseName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prevention)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Solution)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Symptoms)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.Property(e => e.DistrictName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Districts_IsActive");

            entity.HasOne(d => d.Division).WithMany(p => p.Districts)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Districts_Divisions");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.Property(e => e.DivisionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Divisions_IsActive");
        });

        modelBuilder.Entity<Farmer>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LandSize)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.District).WithMany(p => p.Farmers)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Farmers_Districts");

            entity.HasOne(d => d.Division).WithMany(p => p.Farmers)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_Farmers_Divisions");
        });

        modelBuilder.Entity<Fertilizer>(entity =>
        {
            entity.Property(e => e.FertilizerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Fertilizers_IsActive");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsageInstruction)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.Property(e => e.SeasonName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SoilType>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoilName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WaterRequirement>(entity =>
        {
            entity.Property(e => e.LevelName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
