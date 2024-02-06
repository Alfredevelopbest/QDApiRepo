using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QD_API.Models;

public partial class SaleInvoice
{
    public long Id { get; set; }

    public DateTime SaleDate { get; set; }

    public DateOnly DeliveryDate { get; set; }
    
    [Required]
    public long CustomId { get; set; }

    [Required]
    public string DeliveryAddress { get; set; }
    [Required]
    public long DetailInvoiceId { get; set; }

    public virtual Customer Custom { get; set; }

    public virtual DetailInvoice DetailInvoice { get; set; }
}
