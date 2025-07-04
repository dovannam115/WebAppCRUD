using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControlCenterApp.Models;

[Table("A3_STD_UPR_SYSTEM")]
public partial class A3StdUprSystem
{
    [Key]
    [Column("OBJ_ID")]
    public Guid ObjId { get; set; }

    [Column("UPR_SYSTEM")]
    [StringLength(100)]
    public string UprSystem { get; set; } = null!;

    [Column("OBJ_DESCRIPTION")]
    [StringLength(255)]
    public string? ObjDescription { get; set; }

    [InverseProperty("UprSystem")]
    public virtual ICollection<A3StdGldeMapRule> A3StdGldeMapRules { get; set; } = new List<A3StdGldeMapRule>();
}
