using System;
using System.Collections.Generic;
using ControlCenterApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlCenterApp.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<A3StdSaleunit> A3StdSaleunits { get; set; }

    public virtual DbSet<A3StdSaleunitGroup> A3StdSaleunitGroups { get; set; }

    public virtual DbSet<A3StdSaleunitRegion> A3StdSaleunitRegions { get; set; }

    public virtual DbSet<A3StdSaleunitType> A3StdSaleunitTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<A3StdSaleunit>(entity =>
        {
            entity.HasKey(e => e.SaleunitId).HasName("PK__A3_STD_S__0BC194CCC05F21EC");

            entity.ToTable("A3_STD_SALEUNIT");

            entity.Property(e => e.SaleunitId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("SALEUNIT_ID");
            entity.Property(e => e.InsertTime)
                .HasColumnType("datetime")
                .HasColumnName("INSERT_TIME");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("NOTE");
            entity.Property(e => e.PlReviewCfg).HasColumnName("PL_REVIEW_CFG");
            entity.Property(e => e.SaleunitCode)
                .HasMaxLength(255)
                .HasColumnName("SALEUNIT_CODE");
            entity.Property(e => e.SaleunitGroupId).HasColumnName("SALEUNIT_GROUP_ID");
            entity.Property(e => e.SaleunitName)
                .HasMaxLength(255)
                .HasColumnName("SALEUNIT_NAME");
            entity.Property(e => e.SaleunitRegionId).HasColumnName("SALEUNIT_REGION_ID");
            entity.Property(e => e.SaleunitTypeId).HasColumnName("SALEUNIT_TYPE_ID");

            entity.HasOne(d => d.SaleunitGroup).WithMany(p => p.A3StdSaleunits)
                .HasForeignKey(d => d.SaleunitGroupId)
                .HasConstraintName("FK__A3_STD_SA__SALEU__5FDD86D2");

            entity.HasOne(d => d.SaleunitRegion).WithMany(p => p.A3StdSaleunits)
                .HasForeignKey(d => d.SaleunitRegionId)
                .HasConstraintName("FK__A3_STD_SA__SALEU__60D1AB0B");

            entity.HasOne(d => d.SaleunitType).WithMany(p => p.A3StdSaleunits)
                .HasForeignKey(d => d.SaleunitTypeId)
                .HasConstraintName("FK__A3_STD_SA__SALEU__5EE96299");
        });

        modelBuilder.Entity<A3StdSaleunitGroup>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_S__755589F014AB5B30");

            entity.ToTable("A3_STD_SALEUNIT_GROUP");

            entity.HasIndex(e => e.SaleunitGroup, "UQ__A3_STD_S__8579A5B8F6CE0C6B").IsUnique();

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.ObjDescription)
                .HasMaxLength(255)
                .HasColumnName("OBJ_DESCRIPTION");
            entity.Property(e => e.SaleunitGroup)
                .HasMaxLength(50)
                .HasColumnName("SALEUNIT_GROUP");
        });

        modelBuilder.Entity<A3StdSaleunitRegion>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_S__755589F0B67C4B92");

            entity.ToTable("A3_STD_SALEUNIT_REGION");

            entity.HasIndex(e => e.SaleunitRegion, "UQ__A3_STD_S__00B8C506E2D35EA1").IsUnique();

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.ObjDescription)
                .HasMaxLength(255)
                .HasColumnName("OBJ_DESCRIPTION");
            entity.Property(e => e.SaleunitRegion)
                .HasMaxLength(50)
                .HasColumnName("SALEUNIT_REGION");
        });

        modelBuilder.Entity<A3StdSaleunitType>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_S__755589F00B2EB354");

            entity.ToTable("A3_STD_SALEUNIT_TYPE");

            entity.HasIndex(e => e.SaleunitType, "UQ__A3_STD_S__C69E69E1753C898F").IsUnique();

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.ObjDescription)
                .HasMaxLength(255)
                .HasColumnName("OBJ_DESCRIPTION");
            entity.Property(e => e.SaleunitType)
                .HasMaxLength(50)
                .HasColumnName("SALEUNIT_TYPE");
        });
        modelBuilder.HasSequence("sq_default");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
