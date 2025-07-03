using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdSaleunitRegionMetadata))]
public partial class A3StdSaleunitRegion
{
}

internal class A3StdSaleunitRegionMetadata
{
    [Display(Name = "Region")]
    public string SaleunitRegion { get; set; } = default!;

    [Display(Name = "Description")]
    public string? ObjDescription { get; set; }
}
