using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControlCenterApp.Models;

[Table("A3_STD_SALEUNIT_TYPE")]
[Index("SaleunitType", Name = "UQ__A3_STD_S__C69E69E1753C898F", IsUnique = true)]
public partial class A3StdSaleunitType
{
    [Key]
    [Column("OBJ_ID")]
    public Guid ObjId { get; set; }

    [Column("SALEUNIT_TYPE")]
    [StringLength(50)]
    public string SaleunitType { get; set; } = null!;

    [Column("OBJ_DESCRIPTION")]
    [StringLength(255)]
    public string? ObjDescription { get; set; }

    [InverseProperty("SaleunitType")]
    public virtual ICollection<A3StdSaleunit> A3StdSaleunits { get; set; } = new List<A3StdSaleunit>();
}
