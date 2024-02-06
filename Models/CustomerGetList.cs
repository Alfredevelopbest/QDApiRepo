using System;
using System.Collections.Generic;

namespace QD_API.Models;

public partial class CustomerGetList
{
    public long? Id { get; set; }

    public string CustomerName { get; set; }

    public string CustomerLastname { get; set; }

    public short? DocumentTypeId { get; set; }

    public string DocumentNumber { get; set; }

    public string TelephoneNumber { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public short? CityId { get; set; }
}
