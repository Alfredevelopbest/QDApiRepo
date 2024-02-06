using System;
using System.Collections.Generic;

namespace QD_API.Models;

public partial class ProductImage
{
    public long Id { get; set; }

    public string IdIdentifier { get; set; }

    public string ImageName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
