using QD_API.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QD_API.Models;

public partial class Product
{
    public int Id { get; set; }

    [Required]
    public string ReferenceCode { get; set; }

    [Required]
    public decimal SaleProductPrice { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public string ProductName { get; set; }
    [FirstCharUpper]
    [Required]
    public short SizeStandardId { get; set; }


    public long ProductImageId { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<DetailInvoice> DetailInvoices { get; set; } = new List<DetailInvoice>();

    public virtual ProductImage ProductImage { get; set; }

    public virtual StandardSize SizeStandard { get; set; }
}
