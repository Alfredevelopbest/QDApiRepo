using QD_API.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QD_API.Models;

public partial class Customer
{
    public long Id { get; set; }
    [Required]
    [FirstCharUpper]
    public string CustomerName { get; set; }
    [Required]
    [FirstCharUpper]
    public string CustomerLastname { get; set; }
    [Required]
    public short DocumentTypeId { get; set; }
    [Required]
    public string DocumentNumber { get; set; }
    [Required]
    public string TelephoneNumber { get; set; }

    public string Address { get; set; }
    //[Required]
    public string Email { get; set; }
    [Required]
    public short CityId { get; set; }

    public virtual City City { get; set; }

    public virtual DocumentType DocumentType { get; set; }

    public virtual ICollection<SaleInvoice> SaleInvoices { get; set; } = new List<SaleInvoice>();
}
