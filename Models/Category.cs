using QD_API.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QD_API.Models;

public partial class Category
{
    public int Id { get; set; }
    //[Required]
    //[FirstCharUpper]
    public string CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
