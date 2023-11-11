using GoodsMart.DAL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsMart.Bl;

public class ProductAddDto
{
    [MaxLength(50)]
    [MinLength(5)]
    public string Name { get; set; } = string.Empty;
    [Range(0, 1000000, ErrorMessage = "The Price must be between {1} and {2}")]
    public double Price { get; set; }
    [DateMustBeInFuture(ErrorMessage = "the Expiration date must be after 30 days minimully")]    //custum validation
    public DateTime ExpiryDate { get; set; }
}

