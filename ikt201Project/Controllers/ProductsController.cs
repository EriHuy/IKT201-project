using Microsoft.AspNetCore.Mvc;
using ikt201Project.Data;
using ikt201Project.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace ikt201Project.Controllers;


public class ProductsController : Controller
{
    
    private readonly ApplicationDbContext _db;

    public ProductsController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var product = _db.Products.ToList();

        return View(product);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View(new Product());
    }
    [HttpPost]
    public IActionResult Add(Product product)
    {
    
        bool isDuplicateProductId = _db.Products.Any(p => p.ProductId == product.ProductId);

        if (isDuplicateProductId)
        {
            ModelState.AddModelError("ProductId", "A product with this ID already exists.");
        }

        if (product.ProductId <= 0)
        {
            ModelState.AddModelError("ProductId", "Invalid product ID.");
        }
        
        if (!ModelState.IsValid)
            return View(product);

        _db.Products.Add(product);
        _db.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Update(int productId)
    {
        
        var existingProduct = _db.Products.Find(productId);

        if (existingProduct == null)
        {
            ModelState.AddModelError("ProductId", "Invalid product ID.");
        }
        
        return View(existingProduct);
    }

    [HttpPost]
    public IActionResult Update(int productId, Product updatedProduct)
    {
        if (!ModelState.IsValid)
        {
            return View(updatedProduct);
        }
        var existingProduct = _db.Products.Find(productId);
        
        if (existingProduct == null)
        {
            return NotFound();
        }
        
        existingProduct.ProductName = updatedProduct.ProductName;
        existingProduct.Description = updatedProduct.Description;
        existingProduct.Price = updatedProduct.Price;
        existingProduct.ImageUrl = updatedProduct.ImageUrl;
        existingProduct.Quantity = updatedProduct.Quantity;

        _db.Update(existingProduct);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult Delete(int productId)
    {
        var existingProduct = _db.Products.Find(productId);

        if (existingProduct == null)
        {
            return NotFound();
        }

        _db.Products.Remove(existingProduct);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Search(string searchString)
    {
        var products = _db.Products.ToList();

        if (!string.IsNullOrEmpty(searchString))
        {
            products = products.Where(p => p.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

        }

        return View("Index", products);
    }

}