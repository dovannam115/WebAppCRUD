using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3GldeStdProductMetadata))]
public partial class A3GldeStdProduct
{
}

internal class A3GldeStdProductMetadata
{
    [Display(Name = "Code")]
    public string PProduct { get; set; } = default!;

    [Display(Name = "Product ID")]
    public int? PProductId { get; set; }

    [Display(Name = "Product Master ID")]
    public int? PProductMasterId { get; set; }

    [Display(Name = "Name")]
    public string? PProductName { get; set; }

    [Display(Name = "System")]
    public string PSystem { get; set; } = default!;

    [Display(Name = "IAS LOB")]
    public string IasLob { get; set; } = default!;

    [Display(Name = "SUN LOB")]
    public string? SunLob { get; set; }

    [Display(Name = "MOF C50 LOB")]
    public string? MofC50Lob { get; set; }

    [Display(Name = "MOF C67 LOB")]
    public string? MofC67Lob { get; set; }

    [Display(Name = "Product Group")]
    public string? ProductGroup { get; set; }

    [Display(Name = "Transport Means")]
    public string? TransportMeans { get; set; }

    [Display(Name = "Group L2")]
    public Guid? ProductGroupL2Id { get; set; }
}
