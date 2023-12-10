using ikt201Project.Models;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;

namespace ikt201Project.Data;

public class ApplicationDbInitializer
{
    public static void Initialize(ApplicationDbContext db)
    {
        db.Database.EnsureDeleted();

        db.Database.EnsureCreated();
        
        var products = new[]
        {
            new Product(1, "Caps", "Blue cap very nice", 100, "https://hatteshoppen.no/images/zoom/bd-bc153.jpg", 10),
            new Product(2, "Pen", "Pen for rich people", 6, "https://penstore.no/bilder/artiklar/zoom/101628_1.jpg?m=1676989674", 10),
            new Product(3, "Pen", "Pen for rich people", 6, "https://penstore.no/bilder/artiklar/zoom/101628_1.jpg?m=1676989674", 10),
            new Product(4, "Pen", "Pen for rich people", 6, "https://penstore.no/bilder/artiklar/zoom/101628_1.jpg?m=1676989674", 10),
            new Product(5, "Pen", "Pen for rich people", 6, "https://penstore.no/bilder/artiklar/zoom/101628_1.jpg?m=1676989674", 10),
            new Product(6, "Pen", "Pen for rich people", 6, "https://penstore.no/bilder/artiklar/zoom/101628_1.jpg?m=1676989674", 10),
            new Product(7, "Pen", "Pen for rich people", 6, "https://hatteshoppen.no/images/zoom/bd-bc153.jpg", 10)
        };

        var carts = new[]
        {
            new Cart(1, "", 0, 1, "")
        };
        
        
        
        db.Carts.AddRange(carts);
        db.Products.AddRange(products);

        db.SaveChanges();
        
        UpdateCartItems(db);
        
    }
    
    private static void UpdateCartItems(ApplicationDbContext db)
    {
        var carts = db.Carts.ToList();

        foreach (var cart in carts)
        {
            var product = db.Products.Find(cart.ProductId);

            if (product != null)
            {
                cart.ProductName = product.ProductName;
                cart.Price = product.Price;
                cart.ImageUrl = product.ImageUrl;
            }
            else
            {
                db.Carts.Remove(cart);
            }
        }
        db.SaveChanges();
    }
    
}