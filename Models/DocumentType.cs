using QD_API.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QD_API.Models;

public partial class DocumentType
{
    public short Id { get; set; }
    [Required]
    [FirstCharacterUpperAttribute]
    public string DocumentName { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
