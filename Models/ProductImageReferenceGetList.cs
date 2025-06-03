using QD_API.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QD_API.Models;

public partial class ProductImageReferenceGetList
{
    public long Id { get; set; }

    [Required]
    public string IdIdentifier { get; set; }
    [Required]
    public string ImageName { get; set; }
}
