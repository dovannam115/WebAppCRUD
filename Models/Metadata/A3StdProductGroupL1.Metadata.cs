using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdProductGroupL1Metadata))]
public partial class A3StdProductGroupL1
{
}

internal class A3StdProductGroupL1Metadata
{
    [Display(Name = "Group")]
    public string ProductGroupL1 { get; set; } = default!;

    [Display(Name = "Description")]
    public string? ObjDescription { get; set; }
}
