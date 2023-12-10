using Microsoft.AspNetCore.Mvc;
using ikt201Project.Data;
using ikt201Project.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ikt201Project.Controllers;

public class CartController : Controller
{
    private readonly ApplicationDbContext _db;

    public CartController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        CheckItem(_db);
        
        var cart = _db.Carts.ToList();
        
        return View(cart);
    }
        
    
    
    [HttpPost]
    public IActionResult AddItem(int productId)
    {
        var cartItem = _db.Carts.SingleOrDefault(c => c.ProductId == productId);
       
        if (cartItem == null)
        {
            var carts = new Cart(productId, "", 0, 1, "");
            _db.Add(carts);
        }
        else
        {
            cartItem.Quantity++;
        }
        
        _db.SaveChanges();
        UpdateCartItems(_db);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ActionName("RemoveItem")]
    public IActionResult RemoveItem(int productId)
    {
        var existingProduct = _db.Carts.Find(productId);

        if (existingProduct == null)
        {
            return NotFound();
        }

        _db.Carts.Remove(existingProduct);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult UpdateItem(int productId, int quantity)
    {
        var existingProduct = _db.Carts.Find(productId);

        if (existingProduct != null)
        {
            existingProduct.Quantity = quantity;
        }
        _db.SaveChanges();

        return RedirectToAction(nameof(Index));
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
        }
        db.SaveChanges();
    }

    private void CheckItem(ApplicationDbContext db)
    {
        var cart = _db.Carts.ToList();
        foreach (var carts in cart)
        {
            var product = _db.Products.Find(carts.ProductId);

            if (product != null)
            {
                carts.ProductName = product.ProductName;
                carts.Price = product.Price;
                carts.ImageUrl = product.ImageUrl;
            }
            else
            {
                _db.Carts.Remove(carts);
            }
        }
        _db.SaveChanges();
    }
}