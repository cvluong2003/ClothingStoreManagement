using System;
using System.Collections.Generic;

namespace DAL.DBContext;

public partial class Color
{
    public string ColorId { get; set; } = null!;

    public string? ColorName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
