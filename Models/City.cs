using QD_API.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QD_API.Models;

public partial class City
{
    public short Id { get; set; }
    [Required]
    [FirstCharacterUpperAttribute]
    public string CityName { get; set; }

    public City(short Id, string CityName)
    {
        this.Id = Id;
        this.CityName = CityName;
    }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
