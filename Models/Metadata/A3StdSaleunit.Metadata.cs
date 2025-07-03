using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdSaleunitMetadata))]
public partial class A3StdSaleunit
{
}

internal class A3StdSaleunitMetadata
{
    [Display(Name = "Code")]
    public string SaleunitCode { get; set; } = default!;

    [Display(Name = "Name")]
    public string? SaleunitName { get; set; }

    [Display(Name = "Note")]
    public string? Note { get; set; }

    [Display(Name = "PL Review Cfg")]
    public int PlReviewCfg { get; set; }

    [Display(Name = "Insert Time")]
    public DateTime? InsertTime { get; set; }

    [Display(Name = "Type")]
    public Guid? SaleunitTypeId { get; set; }

    [Display(Name = "Group")]
    public Guid? SaleunitGroupId { get; set; }

    [Display(Name = "Region")]
    public Guid? SaleunitRegionId { get; set; }
}
