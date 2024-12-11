using System;
using System.Collections.Generic;

namespace API.DataTranferObject;

public partial class ProductDTO
{
    //public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }

    //public string Status { get; set; }

    public string? ManufacturerId { get; set; }

    public string? CategoryId { get; set; }

   
}
