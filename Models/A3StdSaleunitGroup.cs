using System;
using System.Collections.Generic;

namespace ControlCenterApp.Models;

public partial class A3StdSaleunitGroup
{
    public Guid ObjId { get; set; }

    public string SaleunitGroup { get; set; } = null!;

    public string? ObjDescription { get; set; }

    public virtual ICollection<A3StdSaleunit> A3StdSaleunits { get; set; } = new List<A3StdSaleunit>();
}
