using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdUprSystemMetadata))]
public partial class A3StdUprSystem
{
}

internal class A3StdUprSystemMetadata
{
    [Display(Name = "Group")]
    public string UprSystem { get; set; } = default!;

    [Display(Name = "Description")]
    public string? ObjDescription { get; set; }
}
