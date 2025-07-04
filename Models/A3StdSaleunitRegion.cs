using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControlCenterApp.Models;

[Table("A3_STD_SALEUNIT_REGION")]
[Index("SaleunitRegion", Name = "UQ__A3_STD_S__00B8C506E2D35EA1", IsUnique = true)]
public partial class A3StdSaleunitRegion
{
    [Key]
    [Column("OBJ_ID")]
    public Guid ObjId { get; set; }

    [Column("SALEUNIT_REGION")]
    [StringLength(50)]
    public string SaleunitRegion { get; set; } = null!;

    [Column("OBJ_DESCRIPTION")]
    [StringLength(255)]
    public string? ObjDescription { get; set; }

    [InverseProperty("SaleunitRegion")]
    public virtual ICollection<A3StdSaleunit> A3StdSaleunits { get; set; } = new List<A3StdSaleunit>();
}
