using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenterApp.Models;

[ModelMetadataType(typeof(A3StdGldeMapOrderMetadata))]
public partial class A3StdGldeMapOrder
{
}

internal class A3StdGldeMapOrderMetadata
{
    [Display(Name = "Map Order")]
    public string MapOrder { get; set; } = default!;

    [Display(Name = "Description")]
    public string? ObjDescription { get; set; }

    [Display(Name = "Logic Order")]
    public int? LogicOrder { get; set; }

    [Display(Name = "Cfg Branch")]
    public int? CfgBranch { get; set; }

    [Display(Name = "Cfg Dept")]
    public int? CfgDept { get; set; }

    [Display(Name = "Cfg Product")]
    public int? CfgProduct { get; set; }

    [Display(Name = "Cfg Agent")]
    public int? CfgAgent { get; set; }

    [Display(Name = "Cfg Distributor")]
    public int? CfgDistributor { get; set; }
}
