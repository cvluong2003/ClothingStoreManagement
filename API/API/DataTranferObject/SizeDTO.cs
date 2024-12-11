using System;
using System.Collections.Generic;

namespace API.DataTranferObject;

public partial class SizeDTO
{
    public string SizeId { get; set; }

    public string SizeName { get; set; }

    public int SuitableHeight { get; set; }

    public string SuitableWidth { get; set; }
}
