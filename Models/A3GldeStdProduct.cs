using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControlCenterApp.Models;

[Table("A3_GLDE_STD_PRODUCT")]
[Index("PProduct", Name = "UQ__A3_GLDE___CDD2A5DD22595589", IsUnique = true)]
public partial class A3GldeStdProduct
{
    [Key]
    [Column("REF_ID")]
    public Guid RefId { get; set; }

    [Column("P_PRODUCT_ID")]
    public int? PProductId { get; set; }

    [Column("P_PRODUCT_MASTER_ID")]
    public int? PProductMasterId { get; set; }

    [Column("P_PRODUCT")]
    [StringLength(30)]
    public string PProduct { get; set; } = null!;

    [Column("P_PRODUCT_NAME")]
    [StringLength(255)]
    public string? PProductName { get; set; }

    [Column("P_SYSTEM")]
    [StringLength(50)]
    public string PSystem { get; set; } = null!;

    [Column("IAS_LOB")]
    [StringLength(20)]
    public string IasLob { get; set; } = null!;

    [Column("SUN_LOB")]
    [StringLength(20)]
    public string? SunLob { get; set; }

    [Column("MOF_C50_LOB")]
    [StringLength(20)]
    public string? MofC50Lob { get; set; }

    [Column("MOF_C67_LOB")]
    [StringLength(20)]
    public string? MofC67Lob { get; set; }

    [Column("PRODUCT_GROUP")]
    [StringLength(100)]
    public string? ProductGroup { get; set; }

    [Column("TRANSPORT_MEANS")]
    [StringLength(100)]
    public string? TransportMeans { get; set; }

    [Column("PRODUCT_GROUP_L2_ID")]
    public Guid? ProductGroupL2Id { get; set; }

    [ForeignKey("ProductGroupL2Id")]
    [InverseProperty("A3GldeStdProducts")]
    public virtual A3StdProductGroupL2? ProductGroupL2 { get; set; }
}
