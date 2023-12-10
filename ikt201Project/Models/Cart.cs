using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ikt201Project.Models;

public class Cart
{
    public Cart(){}

    public Cart(int productId, string name, decimal price, int quantity, string imageUrl)
    {
        ProductId = productId;
        ProductName = name;
        Price = price;
        Quantity = quantity;
        ImageUrl = imageUrl;
    }
    [Key]
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
}