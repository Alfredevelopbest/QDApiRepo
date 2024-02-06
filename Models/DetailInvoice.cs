using System;
using System.Collections.Generic;

namespace QD_API.Models;

public partial class DetailInvoice
{
    public long Id { get; set; }

    public int Units { get; set; }

    public int ProductId { get; set; }

    public decimal? TotalPriceInvoice { get; set; }

    public virtual Product Product { get; set; }

    public virtual ICollection<SaleInvoice> SaleInvoices { get; set; } = new List<SaleInvoice>();
}
