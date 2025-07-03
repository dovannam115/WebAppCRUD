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

    [Display(Name = "Name")]
    public string? PProductName { get; set; }

    [Display(Name = "System")]
    public string PSystem { get; set; } = default!;

    [Display(Name = "Group L2")]
    public Guid? ProductGroupL2Id { get; set; }
}
