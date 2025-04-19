using QD_API.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QD_API.Models;

public partial class StandardSize
{
    public short Id { get; set; }

    [Required]
    public decimal DimensionLenght { get; set; }

    [Required]
    [FirstCharacterUpperAttribute]
    public string SizeName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
