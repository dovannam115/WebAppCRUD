using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdSaleunitGroupMetadata))]
public partial class A3StdSaleunitGroup
{
}

internal class A3StdSaleunitGroupMetadata
{
    [Display(Name = "Group")]
    public string SaleunitGroup { get; set; } = default!;

    [Display(Name = "Description")]
    public string? ObjDescription { get; set; }
}
