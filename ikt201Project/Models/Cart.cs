using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ikt201Project.Models;

public class Cart
{
    public Cart(){}

    public Cart(int id, string name, decimal price, int quantity)
    {
        Id = id;
        ProductName = name;
        Price = price;
        Quantity = quantity;
    }
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    
}