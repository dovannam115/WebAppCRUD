using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControlCenterApp.Models;

[Table("A3_STD_GLDE_MAP_ORDER")]
[Index("CfgBranch", "CfgDept", "CfgProduct", "CfgAgent", "CfgDistributor", Name = "UQ__A3_STD_G__F69E0F9024DAAA55", IsUnique = true)]
public partial class A3StdGldeMapOrder
{
    [Key]
    [Column("OBJ_ID")]
    public Guid ObjId { get; set; }

    [Column("MAP_ORDER")]
    [StringLength(255)]
    public string MapOrder { get; set; } = null!;

    [Column("OBJ_DESCRIPTION")]
    [StringLength(255)]
    public string? ObjDescription { get; set; }

    [Column("LOGIC_ORDER")]
    public int? LogicOrder { get; set; }

    [Column("CFG_BRANCH")]
    public int? CfgBranch { get; set; }

    [Column("CFG_DEPT")]
    public int? CfgDept { get; set; }

    [Column("CFG_PRODUCT")]
    public int? CfgProduct { get; set; }

    [Column("CFG_AGENT")]
    public int? CfgAgent { get; set; }

    [Column("CFG_DISTRIBUTOR")]
    public int? CfgDistributor { get; set; }

    [InverseProperty("MapOrder")]
    public virtual ICollection<A3StdGldeMapRule> A3StdGldeMapRules { get; set; } = new List<A3StdGldeMapRule>();
}
