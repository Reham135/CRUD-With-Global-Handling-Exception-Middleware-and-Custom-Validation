using GoodsMart.DAL.Validations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsMart.DAL;

public class Product
{ 
    public int Id { get; set; }
    [MaxLength(50)]
    [MinLength(5)]
    public string Name { get; set; }=string.Empty;
    [Range(0, 1000000, ErrorMessage = "The Price must be between {1} and {2}")]
    public double Price { get; set; }
    [Column(TypeName = "date")]
    [DateMustBeInFuture(ErrorMessage ="the Expiration date must be after 30 days minimully")]    //custum validation
    public DateTime ExpiryDate { get; set; }
}
