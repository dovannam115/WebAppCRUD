using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdDistributorTypeL3Metadata))]
public partial class A3StdDistributorTypeL3
{
}

internal class A3StdDistributorTypeL3Metadata
{
    [Display(Name = "Group")]
    public string DistributorTypeL3 { get; set; } = default!;

    [Display(Name = "Description")]
    public string? ObjDescription { get; set; }
}
