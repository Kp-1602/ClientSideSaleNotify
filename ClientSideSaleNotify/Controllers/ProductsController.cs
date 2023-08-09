using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientSideSaleNotify.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClientSideSaleNotify.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CCQ3_Team1_ProjectContext _context = new CCQ3_Team1_ProjectContext();

        public ProductsController(/*CCQ3_Team1_ProjectContext context*/)
        {
            //_context = context;
        }


        
      
        [HttpPost]
        [Authorize(Roles = "Platinum")]
        public async Task<IActionResult> OnSaleProducts()
        {
            //Product product = await _context.Products.FirstAsync(m => m.OnSale == true);
            //return View(product);
            //foreach (Product product in _context.Products.Where(m => m.OnSale == true))
            //{
            //    return View(product);
            //}
            //return NotFound();
            //m => m.OnSale == true
            
            var product = await _context.Products
                .ToListAsync();
            //foreach (Product product1 in _context.Products.Where(m => m.OnSale == true))
            //{
            //    return View(product);
            //}
            //if (product == null)
            //{
            //    return NotFound();
            //}

            return View(product.FindAll(m => m.OnSale == true));
        }
    
        //public async Task<string> OnSaleProducts()
        //{
        //   foreach(Product product in _context.Products.Where(m => m.OnSale == true))
        //    {
        //        return  _context.Products
        //    }
        //    return ("Not Found");
        //        }

        // GET: Products/Details/5
       
    }
}
