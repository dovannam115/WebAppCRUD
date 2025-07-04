using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControlCenterApp.Models;

[Table("A3_STD_GLDE_MAP_RULE")]
public partial class A3StdGldeMapRule
{
    [Key]
    [Column("OBJ_ID")]
    public Guid ObjId { get; set; }

    [Column("RULE_NAME")]
    [StringLength(255)]
    public string RuleName { get; set; } = null!;

    [Column("PERIOD_START")]
    public int PeriodStart { get; set; }

    [Column("PERIOD_END")]
    public int PeriodEnd { get; set; }

    [Column("IBMS_BRANCH")]
    [StringLength(50)]
    public string? IbmsBranch { get; set; }

    [Column("IBMS_DEPARTMENT")]
    [StringLength(50)]
    public string? IbmsDepartment { get; set; }

    [Column("IBMS_PRODUCT")]
    [StringLength(50)]
    public string? IbmsProduct { get; set; }

    [Column("AGENT_CODE")]
    [StringLength(100)]
    public string? AgentCode { get; set; }

    [Column("DISTRIBUTOR_CODE")]
    [StringLength(100)]
    public string? DistributorCode { get; set; }

    [Column("SUBSIDIARY_CODE")]
    [StringLength(50)]
    public string? SubsidiaryCode { get; set; }

    [Column("MAP_ORDER_ID")]
    public Guid? MapOrderId { get; set; }

    [Column("SALEUNIT_ID")]
    public Guid? SaleunitId { get; set; }

    [Column("DISTRIBUTOR_TYPE_L1_ID")]
    public Guid? DistributorTypeL1Id { get; set; }

    [Column("DISTRIBUTOR_TYPE_L2_ID")]
    public Guid? DistributorTypeL2Id { get; set; }

    [Column("DISTRIBUTOR_TYPE_L3_ID")]
    public Guid? DistributorTypeL3Id { get; set; }

    [Column("PRODUCT_GROUP_L1_ID")]
    public Guid? ProductGroupL1Id { get; set; }

    [Column("PRODUCT_GROUP_L2_ID")]
    public Guid? ProductGroupL2Id { get; set; }

    [Column("UPR_SYSTEM_ID")]
    public Guid? UprSystemId { get; set; }

    [Column("NOTE")]
    [StringLength(255)]
    public string? Note { get; set; }

    [ForeignKey("DistributorTypeL1Id")]
    [InverseProperty("A3StdGldeMapRules")]
    public virtual A3StdDistributorTypeL1? DistributorTypeL1 { get; set; }

    [ForeignKey("DistributorTypeL2Id")]
    [InverseProperty("A3StdGldeMapRules")]
    public virtual A3StdDistributorTypeL2? DistributorTypeL2 { get; set; }

    [ForeignKey("DistributorTypeL3Id")]
    [InverseProperty("A3StdGldeMapRules")]
    public virtual A3StdDistributorTypeL3? DistributorTypeL3 { get; set; }

    [ForeignKey("MapOrderId")]
    [InverseProperty("A3StdGldeMapRules")]
    public virtual A3StdGldeMapOrder? MapOrder { get; set; }

    [ForeignKey("ProductGroupL1Id")]
    [InverseProperty("A3StdGldeMapRules")]
    public virtual A3StdProductGroupL1? ProductGroupL1 { get; set; }

    [ForeignKey("ProductGroupL2Id")]
    [InverseProperty("A3StdGldeMapRules")]
    public virtual A3StdProductGroupL2? ProductGroupL2 { get; set; }

    [ForeignKey("SaleunitId")]
    [InverseProperty("A3StdGldeMapRules")]
    public virtual A3StdSaleunit? Saleunit { get; set; }

    [ForeignKey("UprSystemId")]
    [InverseProperty("A3StdGldeMapRules")]
    public virtual A3StdUprSystem? UprSystem { get; set; }
}
