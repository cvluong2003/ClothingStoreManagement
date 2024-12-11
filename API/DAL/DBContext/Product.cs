using System;
using System.Collections.Generic;

namespace DAL.DBContext;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }

    public bool? SellStatus { get; set; }

    public string? ManufacturerId { get; set; }

    public string? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ICollection<Color> Colors { get; set; } = new List<Color>();
}
