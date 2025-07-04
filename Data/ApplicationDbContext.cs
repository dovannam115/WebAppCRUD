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

    public virtual DbSet<A3GldeStdProduct> A3GldeStdProducts { get; set; }

    public virtual DbSet<A3StdDistributorTypeL1> A3StdDistributorTypeL1s { get; set; }

    public virtual DbSet<A3StdDistributorTypeL2> A3StdDistributorTypeL2s { get; set; }

    public virtual DbSet<A3StdDistributorTypeL3> A3StdDistributorTypeL3s { get; set; }

    public virtual DbSet<A3StdGldeMapOrder> A3StdGldeMapOrders { get; set; }

    public virtual DbSet<A3StdGldeMapRule> A3StdGldeMapRules { get; set; }

    public virtual DbSet<A3StdProductGroupL1> A3StdProductGroupL1s { get; set; }

    public virtual DbSet<A3StdProductGroupL2> A3StdProductGroupL2s { get; set; }

    public virtual DbSet<A3StdSaleunit> A3StdSaleunits { get; set; }

    public virtual DbSet<A3StdSaleunitGroup> A3StdSaleunitGroups { get; set; }

    public virtual DbSet<A3StdSaleunitRegion> A3StdSaleunitRegions { get; set; }

    public virtual DbSet<A3StdSaleunitType> A3StdSaleunitTypes { get; set; }

    public virtual DbSet<A3StdUprSystem> A3StdUprSystems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<A3GldeStdProduct>(entity =>
        {
            entity.HasKey(e => e.RefId).HasName("PK__A3_GLDE___C30DEE1CCF1567CB");

            entity.Property(e => e.RefId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.ProductGroupL2).WithMany(p => p.A3GldeStdProducts).HasConstraintName("FK__A3_GLDE_S__PRODU__59BA9928");
        });

        modelBuilder.Entity<A3StdDistributorTypeL1>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_D__755589F009196217");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<A3StdDistributorTypeL2>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_D__755589F0A89BF11C");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<A3StdDistributorTypeL3>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_D__755589F0A06FB6B0");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<A3StdGldeMapOrder>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_G__755589F06A6EAF95");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CfgAgent).HasDefaultValue(0);
            entity.Property(e => e.CfgBranch).HasDefaultValue(0);
            entity.Property(e => e.CfgDept).HasDefaultValue(0);
            entity.Property(e => e.CfgDistributor).HasDefaultValue(0);
            entity.Property(e => e.CfgProduct).HasDefaultValue(0);
        });

        modelBuilder.Entity<A3StdGldeMapRule>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_G__755589F07341D138");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.PeriodEnd).HasDefaultValue(9999999);

            entity.HasOne(d => d.DistributorTypeL1).WithMany(p => p.A3StdGldeMapRules).HasConstraintName("FK__A3_STD_GL__DISTR__013E7A9D");

            entity.HasOne(d => d.DistributorTypeL2).WithMany(p => p.A3StdGldeMapRules).HasConstraintName("FK__A3_STD_GL__DISTR__02329ED6");

            entity.HasOne(d => d.DistributorTypeL3).WithMany(p => p.A3StdGldeMapRules).HasConstraintName("FK__A3_STD_GL__DISTR__0326C30F");

            entity.HasOne(d => d.MapOrder).WithMany(p => p.A3StdGldeMapRules).HasConstraintName("FK__A3_STD_GL__MAP_O__7F56322B");

            entity.HasOne(d => d.ProductGroupL1).WithMany(p => p.A3StdGldeMapRules).HasConstraintName("FK__A3_STD_GL__PRODU__041AE748");

            entity.HasOne(d => d.ProductGroupL2).WithMany(p => p.A3StdGldeMapRules).HasConstraintName("FK__A3_STD_GL__PRODU__050F0B81");

            entity.HasOne(d => d.Saleunit).WithMany(p => p.A3StdGldeMapRules).HasConstraintName("FK__A3_STD_GL__SALEU__004A5664");

            entity.HasOne(d => d.UprSystem).WithMany(p => p.A3StdGldeMapRules).HasConstraintName("FK__A3_STD_GL__UPR_S__06032FBA");
        });

        modelBuilder.Entity<A3StdProductGroupL1>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_P__755589F0C032F6FF");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<A3StdProductGroupL2>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_P__755589F0CC6E7F02");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<A3StdSaleunit>(entity =>
        {
            entity.HasKey(e => e.SaleunitId).HasName("PK__A3_STD_S__0BC194CCC05F21EC");

            entity.Property(e => e.SaleunitId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.SaleunitGroup).WithMany(p => p.A3StdSaleunits).HasConstraintName("FK__A3_STD_SA__SALEU__5FDD86D2");

            entity.HasOne(d => d.SaleunitRegion).WithMany(p => p.A3StdSaleunits).HasConstraintName("FK__A3_STD_SA__SALEU__60D1AB0B");

            entity.HasOne(d => d.SaleunitType).WithMany(p => p.A3StdSaleunits).HasConstraintName("FK__A3_STD_SA__SALEU__5EE96299");
        });

        modelBuilder.Entity<A3StdSaleunitGroup>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_S__755589F014AB5B30");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<A3StdSaleunitRegion>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_S__755589F0B67C4B92");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<A3StdSaleunitType>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_S__755589F00B2EB354");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<A3StdUprSystem>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_U__755589F049869DF5");

            entity.Property(e => e.ObjId).HasDefaultValueSql("(newid())");
        });
        modelBuilder.HasSequence("sq_default");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
