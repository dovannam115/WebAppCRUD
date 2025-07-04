using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControlCenterApp.Models;

[Table("A3_STD_SALEUNIT_GROUP")]
[Index("SaleunitGroup", Name = "UQ__A3_STD_S__8579A5B8F6CE0C6B", IsUnique = true)]
public partial class A3StdSaleunitGroup
{
    [Key]
    [Column("OBJ_ID")]
    public Guid ObjId { get; set; }

    [Column("SALEUNIT_GROUP")]
    [StringLength(50)]
    public string SaleunitGroup { get; set; } = null!;

    [Column("OBJ_DESCRIPTION")]
    [StringLength(255)]
    public string? ObjDescription { get; set; }

    [InverseProperty("SaleunitGroup")]
    public virtual ICollection<A3StdSaleunit> A3StdSaleunits { get; set; } = new List<A3StdSaleunit>();
}
