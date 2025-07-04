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

    [Display(Name = "IBMS Branch")]
    public string? IbmsBranch { get; set; }

    [Display(Name = "IBMS Department")]
    public string? IbmsDepartment { get; set; }

    [Display(Name = "IBMS Product")]
    public string? IbmsProduct { get; set; }

    [Display(Name = "Agent Code")]
    public string? AgentCode { get; set; }

    [Display(Name = "Distributor Code")]
    public string? DistributorCode { get; set; }

    [Display(Name = "Subsidiary Code")]
    public string? SubsidiaryCode { get; set; }

    [Display(Name = "Map Order")]
    public Guid? MapOrderId { get; set; }

    [Display(Name = "Saleunit")]
    public Guid? SaleunitId { get; set; }

    [Display(Name = "Distributor Type L1")]
    public Guid? DistributorTypeL1Id { get; set; }

    [Display(Name = "Distributor Type L2")]
    public Guid? DistributorTypeL2Id { get; set; }

    [Display(Name = "Distributor Type L3")]
    public Guid? DistributorTypeL3Id { get; set; }

    [Display(Name = "Product Group L1")]
    public Guid? ProductGroupL1Id { get; set; }

    [Display(Name = "Product Group L2")]
    public Guid? ProductGroupL2Id { get; set; }

    [Display(Name = "UPR System")]
    public Guid? UprSystemId { get; set; }

    [Display(Name = "Note")]
    public string? Note { get; set; }
}
