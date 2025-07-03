using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdGldeMapRuleMetadata))]
public partial class A3StdGldeMapRule
{
}

internal class A3StdGldeMapRuleMetadata
{
    [Display(Name = "Name")]
    public string RuleName { get; set; } = default!;

    [Display(Name = "Period Start")]
    public int PeriodStart { get; set; }

    [Display(Name = "Period End")]
    public int PeriodEnd { get; set; }

    [Display(Name = "Map Order")]
    public Guid? MapOrderId { get; set; }

    [Display(Name = "Saleunit")]
    public Guid? SaleunitId { get; set; }

    [Display(Name = "Product Group L2")]
    public Guid? ProductGroupL2Id { get; set; }

    [Display(Name = "UPR System")]
    public Guid? UprSystemId { get; set; }

    [Display(Name = "Note")]
    public string? Note { get; set; }
}
