using System;
using System.Collections.Generic;

namespace DAL.DBContext;

public partial class Manufacturer
{
    public string ManufacturerId { get; set; } = null!;

    public string? ManufacturerName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
