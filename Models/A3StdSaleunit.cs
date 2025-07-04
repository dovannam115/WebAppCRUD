using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControlCenterApp.Models;

[Table("A3_STD_SALEUNIT")]
public partial class A3StdSaleunit
{
    [Key]
    [Column("SALEUNIT_ID")]
    public Guid SaleunitId { get; set; }

    [Column("INSERT_TIME", TypeName = "datetime")]
    public DateTime? InsertTime { get; set; }

    [Column("SALEUNIT_CODE")]
    [StringLength(255)]
    public string SaleunitCode { get; set; } = null!;

    [Column("SALEUNIT_NAME")]
    [StringLength(255)]
    public string? SaleunitName { get; set; }

    [Column("NOTE")]
    [StringLength(255)]
    public string? Note { get; set; }

    [Column("PL_REVIEW_CFG")]
    public int PlReviewCfg { get; set; }

    [Column("SALEUNIT_TYPE_ID")]
    public Guid? SaleunitTypeId { get; set; }

    [Column("SALEUNIT_GROUP_ID")]
    public Guid? SaleunitGroupId { get; set; }

    [Column("SALEUNIT_REGION_ID")]
    public Guid? SaleunitRegionId { get; set; }

    [InverseProperty("Saleunit")]
    public virtual ICollection<A3StdGldeMapRule> A3StdGldeMapRules { get; set; } = new List<A3StdGldeMapRule>();

    [ForeignKey("SaleunitGroupId")]
    [InverseProperty("A3StdSaleunits")]
    public virtual A3StdSaleunitGroup? SaleunitGroup { get; set; }

    [ForeignKey("SaleunitRegionId")]
    [InverseProperty("A3StdSaleunits")]
    public virtual A3StdSaleunitRegion? SaleunitRegion { get; set; }

    [ForeignKey("SaleunitTypeId")]
    [InverseProperty("A3StdSaleunits")]
    public virtual A3StdSaleunitType? SaleunitType { get; set; }
}
