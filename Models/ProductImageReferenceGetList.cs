using QD_API.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QD_API.Models;

public partial class ProductImageReferenceGetList
{
    public long Id { get; set; }

    [Required]
    [FirstCharUpper]
    public string IdIdentifier { get; set; }
    [Required]
    [FirstCharUpper]
    public string ImageName { get; set; }
}
