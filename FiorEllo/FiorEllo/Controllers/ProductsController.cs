using FiorEllo.DAL;
using FiorEllo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiorEllo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        { 
            List<Product> Products = await _db.Products.ToListAsync();
            return View(Products);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = await _db.Products.Include(x=>x.ProductDetail).FirstOrDefaultAsync(x=>x.Id==id);
            //Bir table`dan digər table`a keçəndə Include edirik view`dakı buna => @Model.ProductDetail.Description görə
            if (product == null)
            {
                return BadRequest();
            }
            return View(product);

        }
    }
}
