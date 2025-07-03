using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdDistributorTypeL1Metadata))]
public partial class A3StdDistributorTypeL1
{
}

internal class A3StdDistributorTypeL1Metadata
{
    [Display(Name = "Group")]
    public string DistributorTypeL1 { get; set; } = default!;

    [Display(Name = "Description")]
    public string? ObjDescription { get; set; }
}
