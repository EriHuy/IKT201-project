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
            new Product(3, "Water Bottle", "With unique inspirational quote and time markers on it,this water bottle is great for measuring your daily intake of water,reminding you stay hydrated and drink enough water throughout the day.A must have for any fitness goals including weight loss,appetite control and overall health.", 10, "waterbottle.jpg", 20),
            new Product(4, "School Bag", "Study with style", 30, "https://img.fruugo.com/product/2/16/645250162_max.jpg", 10),
            new Product(5, "Vitage T&J Shirt", "Flex on 'em", 20, "https://www.shirtstore.no/pub_images/original/WB-12-TJ053-AZ.jpg", 5),
            new Product(6, "Diary Note Book", "A diary notebook serves as a personal space for recording thoughts, emotions, and experiences, offering numerous benefits, such as: Self-Reflection, Memory Enhancement and Stress Relief, to name a few.", 10, "https://m.media-amazon.com/images/I/61FboYGthXL._AC_UF1000,1000_QL80_.jpg", 15),
            new Product(7, "Watch", "Go ahead, flex your wrist and tell them the time!", 50, "https://i.ebayimg.com/images/g/1agAAOSwitlhtgCi/s-l1200.webp", 10),
            new Product(8, "LED lights", "Light Up Your Room", 15, "ledlights.jpg", 10),
            new Product(9, "Office Keyboard and Mouse Combo", "Get Down to Business", 15, "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/combos/mk470-slim-wireless-combo/gallery-images/mk470-gallery-graphite-matt-us-01.png?v=1", 15),
            new Product(10, "Ball", "Kick It!", 10, "https://upload.wikimedia.org/wikipedia/commons/1/1d/Football_Pallo_valmiina-cropped.jpg", 30),
            new Product(11, "Funny Costume", "Be the smelliest at the party!", 25, "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1686688348-screen-shot-2023-06-13-at-4-26-32-pm-6488d1b546f2d.png?crop=1xw:0.8574351978171897xh;center,top&resize=980:*", 5),
            new Product(12, "The Whole Story: Shrek", "All shrek movies DVD set. One of the greatest movies ever, great for fun nights with family, friends or just by yourself!", 40, "https://m.media-amazon.com/images/I/91Wl7ErvsgL._AC_UF1000,1000_QL80_.jpg", 10),
            new Product(13, "Blue Light Glasses", "Blue light glasses are designed to reduce the amount of blue light exposure from digital screens, such as those from computers, smartphones, and tablets. Blue light is part of the visible light spectrum and is emitted by electronic devices as well as natural sunlight.", 35, "https://m.media-amazon.com/images/W/MEDIAX_792452-T2/images/I/61oohbntLpL._AC_UY1000_.jpg", 20),
            new Product(14, "Comfortable Pillow", "a comfortable pillow is an investment in quality sleep, offering the right balance of comfort, support, and durability. This is a well-designed and thoughtfully crafted pillow that significantly contribute to better sleep quality, allowing users to wake up feeling rejuvenated", 45, "https://pyxis.nymag.com/v1/imgs/11c/247/45133174fbfb0125bb5690434be08413da-coop-home-goods---premium-adjustable-lof.rsquare.w600.jpg", 10),
            new Product(15, "Dungeon&Dragons Board Game", "QUICK ENTRY TO DUNGEONS & DRAGONS: Step into the exciting world of D&D with the Dungeons & Dragons Adventure Begins board game. Designed for 2-4 players, ages 10 and up", 150, "https://m.media-amazon.com/images/W/MEDIAX_792452-T2/images/I/91BbLvHEBzL.jpg", 10)

        };

        var carts = new[]
        {
            new Cart(1, "", 0, 1, ""),
            new Cart(2, "", 0, 1, "")
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