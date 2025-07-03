using System;
using System.Collections.Generic;

namespace ControlCenterApp.Models;

public partial class A3StdGldeMapOrder
{
    public Guid ObjId { get; set; }

    public string MapOrder { get; set; } = null!;

    public string? ObjDescription { get; set; }

    public int? LogicOrder { get; set; }

    public int? CfgBranch { get; set; }

    public int? CfgDept { get; set; }

    public int? CfgProduct { get; set; }

    public int? CfgAgent { get; set; }

    public int? CfgDistributor { get; set; }

    public virtual ICollection<A3StdGldeMapRule> A3StdGldeMapRules { get; set; } = new List<A3StdGldeMapRule>();
}
