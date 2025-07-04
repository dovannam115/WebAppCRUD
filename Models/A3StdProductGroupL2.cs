using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControlCenterApp.Models;

[Table("A3_STD_PRODUCT_GROUP_L2")]
public partial class A3StdProductGroupL2
{
    [Key]
    [Column("OBJ_ID")]
    public Guid ObjId { get; set; }

    [Column("PRODUCT_GROUP_L2")]
    [StringLength(100)]
    public string ProductGroupL2 { get; set; } = null!;

    [Column("OBJ_DESCRIPTION")]
    [StringLength(255)]
    public string? ObjDescription { get; set; }

    [InverseProperty("ProductGroupL2")]
    public virtual ICollection<A3GldeStdProduct> A3GldeStdProducts { get; set; } = new List<A3GldeStdProduct>();

    [InverseProperty("ProductGroupL2")]
    public virtual ICollection<A3StdGldeMapRule> A3StdGldeMapRules { get; set; } = new List<A3StdGldeMapRule>();
}
