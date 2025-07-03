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

            entity.ToTable("A3_GLDE_STD_PRODUCT");

            entity.HasIndex(e => e.PProduct, "UQ__A3_GLDE___CDD2A5DD22595589").IsUnique();

            entity.Property(e => e.RefId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("REF_ID");
            entity.Property(e => e.IasLob)
                .HasMaxLength(20)
                .HasColumnName("IAS_LOB");
            entity.Property(e => e.MofC50Lob)
                .HasMaxLength(20)
                .HasColumnName("MOF_C50_LOB");
            entity.Property(e => e.MofC67Lob)
                .HasMaxLength(20)
                .HasColumnName("MOF_C67_LOB");
            entity.Property(e => e.PProduct)
                .HasMaxLength(30)
                .HasColumnName("P_PRODUCT");
            entity.Property(e => e.PProductId).HasColumnName("P_PRODUCT_ID");
            entity.Property(e => e.PProductMasterId).HasColumnName("P_PRODUCT_MASTER_ID");
            entity.Property(e => e.PProductName)
                .HasMaxLength(255)
                .HasColumnName("P_PRODUCT_NAME");
            entity.Property(e => e.PSystem)
                .HasMaxLength(50)
                .HasColumnName("P_SYSTEM");
            entity.Property(e => e.ProductGroup)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_GROUP");
            entity.Property(e => e.ProductGroupL2Id).HasColumnName("PRODUCT_GROUP_L2_ID");
            entity.Property(e => e.SunLob)
                .HasMaxLength(20)
                .HasColumnName("SUN_LOB");
            entity.Property(e => e.TransportMeans)
                .HasMaxLength(100)
                .HasColumnName("TRANSPORT_MEANS");

            entity.HasOne(d => d.ProductGroupL2).WithMany(p => p.A3GldeStdProducts)
                .HasForeignKey(d => d.ProductGroupL2Id)
                .HasConstraintName("FK__A3_GLDE_S__PRODU__59BA9928");
        });

        modelBuilder.Entity<A3StdDistributorTypeL1>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_D__755589F009196217");

            entity.ToTable("A3_STD_DISTRIBUTOR_TYPE_L1");

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.DistributorTypeL1)
                .HasMaxLength(100)
                .HasColumnName("DISTRIBUTOR_TYPE_L1");
            entity.Property(e => e.ObjDescription)
                .HasMaxLength(255)
                .HasColumnName("OBJ_DESCRIPTION");
        });

        modelBuilder.Entity<A3StdDistributorTypeL2>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_D__755589F0A89BF11C");

            entity.ToTable("A3_STD_DISTRIBUTOR_TYPE_L2");

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.DistributorTypeL2)
                .HasMaxLength(100)
                .HasColumnName("DISTRIBUTOR_TYPE_L2");
            entity.Property(e => e.ObjDescription)
                .HasMaxLength(255)
                .HasColumnName("OBJ_DESCRIPTION");
        });

        modelBuilder.Entity<A3StdDistributorTypeL3>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_D__755589F0A06FB6B0");

            entity.ToTable("A3_STD_DISTRIBUTOR_TYPE_L3");

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.DistributorTypeL3)
                .HasMaxLength(100)
                .HasColumnName("DISTRIBUTOR_TYPE_L3");
            entity.Property(e => e.ObjDescription)
                .HasMaxLength(255)
                .HasColumnName("OBJ_DESCRIPTION");
        });

        modelBuilder.Entity<A3StdGldeMapOrder>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_G__755589F06A6EAF95");

            entity.ToTable("A3_STD_GLDE_MAP_ORDER");

            entity.HasIndex(e => new { e.CfgBranch, e.CfgDept, e.CfgProduct, e.CfgAgent, e.CfgDistributor }, "UQ__A3_STD_G__F69E0F9024DAAA55").IsUnique();

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.CfgAgent)
                .HasDefaultValue(0)
                .HasColumnName("CFG_AGENT");
            entity.Property(e => e.CfgBranch)
                .HasDefaultValue(0)
                .HasColumnName("CFG_BRANCH");
            entity.Property(e => e.CfgDept)
                .HasDefaultValue(0)
                .HasColumnName("CFG_DEPT");
            entity.Property(e => e.CfgDistributor)
                .HasDefaultValue(0)
                .HasColumnName("CFG_DISTRIBUTOR");
            entity.Property(e => e.CfgProduct)
                .HasDefaultValue(0)
                .HasColumnName("CFG_PRODUCT");
            entity.Property(e => e.LogicOrder).HasColumnName("LOGIC_ORDER");
            entity.Property(e => e.MapOrder)
                .HasMaxLength(255)
                .HasColumnName("MAP_ORDER");
            entity.Property(e => e.ObjDescription)
                .HasMaxLength(255)
                .HasColumnName("OBJ_DESCRIPTION");
        });

        modelBuilder.Entity<A3StdGldeMapRule>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_G__755589F07341D138");

            entity.ToTable("A3_STD_GLDE_MAP_RULE");

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.AgentCode)
                .HasMaxLength(100)
                .HasColumnName("AGENT_CODE");
            entity.Property(e => e.DistributorCode)
                .HasMaxLength(100)
                .HasColumnName("DISTRIBUTOR_CODE");
            entity.Property(e => e.DistributorTypeL1Id).HasColumnName("DISTRIBUTOR_TYPE_L1_ID");
            entity.Property(e => e.DistributorTypeL2Id).HasColumnName("DISTRIBUTOR_TYPE_L2_ID");
            entity.Property(e => e.DistributorTypeL3Id).HasColumnName("DISTRIBUTOR_TYPE_L3_ID");
            entity.Property(e => e.IbmsBranch)
                .HasMaxLength(50)
                .HasColumnName("IBMS_BRANCH");
            entity.Property(e => e.IbmsDepartment)
                .HasMaxLength(50)
                .HasColumnName("IBMS_DEPARTMENT");
            entity.Property(e => e.IbmsProduct)
                .HasMaxLength(50)
                .HasColumnName("IBMS_PRODUCT");
            entity.Property(e => e.MapOrderId).HasColumnName("MAP_ORDER_ID");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("NOTE");
            entity.Property(e => e.PeriodEnd)
                .HasDefaultValue(9999999)
                .HasColumnName("PERIOD_END");
            entity.Property(e => e.PeriodStart).HasColumnName("PERIOD_START");
            entity.Property(e => e.ProductGroupL1Id).HasColumnName("PRODUCT_GROUP_L1_ID");
            entity.Property(e => e.ProductGroupL2Id).HasColumnName("PRODUCT_GROUP_L2_ID");
            entity.Property(e => e.RuleName)
                .HasMaxLength(255)
                .HasColumnName("RULE_NAME");
            entity.Property(e => e.SaleunitId).HasColumnName("SALEUNIT_ID");
            entity.Property(e => e.SubsidiaryCode)
                .HasMaxLength(50)
                .HasColumnName("SUBSIDIARY_CODE");
            entity.Property(e => e.UprSystemId).HasColumnName("UPR_SYSTEM_ID");

            entity.HasOne(d => d.DistributorTypeL1).WithMany(p => p.A3StdGldeMapRules)
                .HasForeignKey(d => d.DistributorTypeL1Id)
                .HasConstraintName("FK__A3_STD_GL__DISTR__013E7A9D");

            entity.HasOne(d => d.DistributorTypeL2).WithMany(p => p.A3StdGldeMapRules)
                .HasForeignKey(d => d.DistributorTypeL2Id)
                .HasConstraintName("FK__A3_STD_GL__DISTR__02329ED6");

            entity.HasOne(d => d.DistributorTypeL3).WithMany(p => p.A3StdGldeMapRules)
                .HasForeignKey(d => d.DistributorTypeL3Id)
                .HasConstraintName("FK__A3_STD_GL__DISTR__0326C30F");

            entity.HasOne(d => d.MapOrder).WithMany(p => p.A3StdGldeMapRules)
                .HasForeignKey(d => d.MapOrderId)
                .HasConstraintName("FK__A3_STD_GL__MAP_O__7F56322B");

            entity.HasOne(d => d.ProductGroupL1).WithMany(p => p.A3StdGldeMapRules)
                .HasForeignKey(d => d.ProductGroupL1Id)
                .HasConstraintName("FK__A3_STD_GL__PRODU__041AE748");

            entity.HasOne(d => d.ProductGroupL2).WithMany(p => p.A3StdGldeMapRules)
                .HasForeignKey(d => d.ProductGroupL2Id)
                .HasConstraintName("FK__A3_STD_GL__PRODU__050F0B81");

            entity.HasOne(d => d.Saleunit).WithMany(p => p.A3StdGldeMapRules)
                .HasForeignKey(d => d.SaleunitId)
                .HasConstraintName("FK__A3_STD_GL__SALEU__004A5664");

            entity.HasOne(d => d.UprSystem).WithMany(p => p.A3StdGldeMapRules)
                .HasForeignKey(d => d.UprSystemId)
                .HasConstraintName("FK__A3_STD_GL__UPR_S__06032FBA");
        });

        modelBuilder.Entity<A3StdProductGroupL1>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_P__755589F0C032F6FF");

            entity.ToTable("A3_STD_PRODUCT_GROUP_L1");

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.ObjDescription)
                .HasMaxLength(255)
                .HasColumnName("OBJ_DESCRIPTION");
            entity.Property(e => e.ProductGroupL1)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_GROUP_L1");
        });

        modelBuilder.Entity<A3StdProductGroupL2>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_P__755589F0CC6E7F02");

            entity.ToTable("A3_STD_PRODUCT_GROUP_L2");

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.ObjDescription)
                .HasMaxLength(255)
                .HasColumnName("OBJ_DESCRIPTION");
            entity.Property(e => e.ProductGroupL2)
                .HasMaxLength(100)
                .HasColumnName("PRODUCT_GROUP_L2");
        });

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

        modelBuilder.Entity<A3StdUprSystem>(entity =>
        {
            entity.HasKey(e => e.ObjId).HasName("PK__A3_STD_U__755589F049869DF5");

            entity.ToTable("A3_STD_UPR_SYSTEM");

            entity.Property(e => e.ObjId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OBJ_ID");
            entity.Property(e => e.ObjDescription)
                .HasMaxLength(255)
                .HasColumnName("OBJ_DESCRIPTION");
            entity.Property(e => e.UprSystem)
                .HasMaxLength(100)
                .HasColumnName("UPR_SYSTEM");
        });
        modelBuilder.HasSequence("sq_default");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
