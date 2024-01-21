using System.ComponentModel.DataAnnotations;

namespace CodeFirst;
public class Category
{
    [Key]
    public int Id { get; set; } 

    [Required, MaxLength(30), RegularExpression("^[A-Z][a-z]+$")]
    public string Name { get; set; } 
    
    /*
    нужно для связи один ко многим.
    В базе данных этого списка не будет,
    но при этом в С# коде мы сможем получить список продуктов, которые относятся к данной категории.
    */
    public ICollection<Product> Products { get; set; } 
}


