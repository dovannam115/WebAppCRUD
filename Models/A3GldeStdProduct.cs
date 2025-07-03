using System;
using System.Collections.Generic;

namespace ControlCenterApp.Models;

public partial class A3GldeStdProduct
{
    public Guid RefId { get; set; }

    public int? PProductId { get; set; }

    public int? PProductMasterId { get; set; }

    public string PProduct { get; set; } = null!;

    public string? PProductName { get; set; }

    public string PSystem { get; set; } = null!;

    public string IasLob { get; set; } = null!;

    public string? SunLob { get; set; }

    public string? MofC50Lob { get; set; }

    public string? MofC67Lob { get; set; }

    public string? ProductGroup { get; set; }

    public string? TransportMeans { get; set; }

    public Guid? ProductGroupL2Id { get; set; }

    public virtual A3StdProductGroupL2? ProductGroupL2 { get; set; }
}
