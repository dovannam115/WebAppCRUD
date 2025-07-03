using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdSaleunitTypeMetadata))]
public partial class A3StdSaleunitType
{
}

internal class A3StdSaleunitTypeMetadata
{
    [Display(Name = "Type")]
    public string SaleunitType { get; set; } = default!;

    [Display(Name = "Description")]
    public string? ObjDescription { get; set; }
}
