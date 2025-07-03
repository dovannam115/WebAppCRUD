using System;
using System.Collections.Generic;

namespace ControlCenterApp.Models;

public partial class A3StdGldeMapRule
{
    public Guid ObjId { get; set; }

    public string RuleName { get; set; } = null!;

    public int PeriodStart { get; set; }

    public int PeriodEnd { get; set; }

    public string? IbmsBranch { get; set; }

    public string? IbmsDepartment { get; set; }

    public string? IbmsProduct { get; set; }

    public string? AgentCode { get; set; }

    public string? DistributorCode { get; set; }

    public string? SubsidiaryCode { get; set; }

    public Guid? MapOrderId { get; set; }

    public Guid? SaleunitId { get; set; }

    public Guid? DistributorTypeL1Id { get; set; }

    public Guid? DistributorTypeL2Id { get; set; }

    public Guid? DistributorTypeL3Id { get; set; }

    public Guid? ProductGroupL1Id { get; set; }

    public Guid? ProductGroupL2Id { get; set; }

    public Guid? UprSystemId { get; set; }

    public string? Note { get; set; }

    public virtual A3StdDistributorTypeL1? DistributorTypeL1 { get; set; }

    public virtual A3StdDistributorTypeL2? DistributorTypeL2 { get; set; }

    public virtual A3StdDistributorTypeL3? DistributorTypeL3 { get; set; }

    public virtual A3StdGldeMapOrder? MapOrder { get; set; }

    public virtual A3StdProductGroupL1? ProductGroupL1 { get; set; }

    public virtual A3StdProductGroupL2? ProductGroupL2 { get; set; }

    public virtual A3StdSaleunit? Saleunit { get; set; }

    public virtual A3StdUprSystem? UprSystem { get; set; }
}
