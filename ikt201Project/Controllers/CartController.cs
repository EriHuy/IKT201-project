using Microsoft.AspNetCore.Mvc;
using ikt201Project.Data;
using ikt201Project.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ikt201Project.Controllers;

public class CartController : Controller
{
    public int ShoppingCartId { get; set; }

    private readonly ApplicationDbContext _db;

    public CartController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public void AddItem(int productId)
    {
        
    }

    public void RemoveItem(int productId)
    {
        
    }

    public void UpdateItem(int productId, int quantity)
    {
        
    }
}