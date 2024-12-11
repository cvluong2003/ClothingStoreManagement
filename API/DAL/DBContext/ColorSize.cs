using System;
using System.Collections.Generic;

namespace DAL.DBContext;

public partial class ColorSize
{
    public string? ColorId { get; set; }

    public string? SizeId { get; set; }

    public virtual Color? Color { get; set; }

    public virtual Size? Size { get; set; }
}
