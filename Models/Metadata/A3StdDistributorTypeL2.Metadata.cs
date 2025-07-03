using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdDistributorTypeL2Metadata))]
public partial class A3StdDistributorTypeL2
{
}

internal class A3StdDistributorTypeL2Metadata
{
    [Display(Name = "Group")]
    public string DistributorTypeL2 { get; set; } = default!;

    [Display(Name = "Description")]
    public string? ObjDescription { get; set; }
}
