using System;
using System.Collections.Generic;

namespace DAL.DBContext;

public partial class Size
{
    public string SizeId { get; set; } = null!;

    public string? SizeName { get; set; }

    public int? SuitableHeight { get; set; }

    public string? SuitableWidth { get; set; }
}
