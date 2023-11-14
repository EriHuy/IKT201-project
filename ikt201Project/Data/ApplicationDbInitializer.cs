using ikt201Project.Models;

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
            new Product(7, "Pen", "Pen for rich people", 6, "https://penstore.no/bilder/artiklar/zoom/101628_1.jpg?m=1676989674", 10)
        };
            
        db.Products.AddRange(products);

        db.SaveChanges();

    }
}