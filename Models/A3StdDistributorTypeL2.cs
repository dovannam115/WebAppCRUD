using System;
using System.Collections.Generic;

namespace ControlCenterApp.Models;

public partial class A3StdDistributorTypeL2
{
    public Guid ObjId { get; set; }

    public string DistributorTypeL2 { get; set; } = null!;

    public string? ObjDescription { get; set; }

    public virtual ICollection<A3StdGldeMapRule> A3StdGldeMapRules { get; set; } = new List<A3StdGldeMapRule>();
}
