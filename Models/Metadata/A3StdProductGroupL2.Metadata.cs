using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdProductGroupL2Metadata))]
public partial class A3StdProductGroupL2
{
}

internal class A3StdProductGroupL2Metadata
{
    [Display(Name = "Group")]
    public string ProductGroupL2 { get; set; } = default!;

    [Display(Name = "Description")]
    public string? ObjDescription { get; set; }
}
