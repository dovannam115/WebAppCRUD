using System;
using System.Collections.Generic;

namespace ControlCenterApp.Models;

public partial class A3StdSaleunit
{
    public Guid SaleunitId { get; set; }

    public DateTime? InsertTime { get; set; }

    public string SaleunitCode { get; set; } = null!;

    public string? SaleunitName { get; set; }

    public string? Note { get; set; }

    public int PlReviewCfg { get; set; }

    public Guid? SaleunitTypeId { get; set; }

    public Guid? SaleunitGroupId { get; set; }

    public Guid? SaleunitRegionId { get; set; }

    public virtual A3StdSaleunitGroup? SaleunitGroup { get; set; }

    public virtual A3StdSaleunitRegion? SaleunitRegion { get; set; }

    public virtual A3StdSaleunitType? SaleunitType { get; set; }
}
