using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ikt201Project.Models;

public class Product
{
    public Product() {}

    public Product(int id, string name, string description, decimal price, string imageUrl, int quantity)
    {
        ProductId = id;
        ProductName = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        Quantity = quantity;
    }
    
    public int ProductId { get; set; }

    [Required]
    [DisplayName("Name")]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    [StringLength(300, MinimumLength = 0)]
    [DisplayName("Description")]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public decimal Price { get; set; }

    [Required] 
    public string ImageUrl { get; set; }

    [Required] 
    public int Quantity { get; set; }
}