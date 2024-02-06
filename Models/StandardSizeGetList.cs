using System;
using System.Collections.Generic;

namespace QD_API.Models;

public partial class StandardSizeGetList
{
    public short? Id { get; set; }

    public decimal? DimensionLenght { get; set; }

    public string SizeName { get; set; }
}
