using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechDataLayer;

public class Category
{
    [Key]
    public int Id { get; set; } 

    [Required, MaxLength(30), RegularExpression("^[A-Z][a-z]+$")]
    public string Name { get; set; } 
    
    public ICollection<Product> Products { get; set; } 
}
