using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextwoIdentity2023.Data;
using NextwoIdentity2023.Models.ViewModel;

namespace NextwoIdentity2023.Controllers
{
    public class ProductController : Controller

    {
        #region Configuration

        private readonly NextwoDbcontext _context;
        private NextwoDbcontext db;

        public ProductController(NextwoDbcontext context, NextwoDbcontext _db)
        {
            _context = context;
            db = _db;
        }

        #endregion

        #region Product

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            ViewBag.allDept = new SelectList(db.Categorys, "CategoryId", "CategoryName");
            return View(_context.Products.Include(x => x.Category));
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.allDept = new SelectList(db.Categorys, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("AllProducts");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsProduct(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllProducts");
            }
            var data = db.Products.Find(id);
            /*            ViewBag.allDept = new SelectList(db.Categorys, "CategoryId", "CategoryName");
            */
            if (data == null)
            {
                return RedirectToAction("AllProducts");
            }
            return View(data);

        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllProducts");
            }
            var data = db.Products.Find(id);
            if (data == null)
            {
                return RedirectToAction("AllProducts");
            }
            ViewBag.allDept = new SelectList(db.Categorys, "CategoryId", "CategoryName");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Update(product);
                db.SaveChanges();
                return RedirectToAction("AllProducts");
            }
            return View(product);

        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllProducts");
            }
            var data = db.Products.Find(id);
            if (data == null)
            {
                return RedirectToAction("AllProducts");
            }
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("AllProducts");
            }
            return View(product);

        }

        public async Task<IActionResult> Errorpage()
        {
            return View();
        }

        #endregion
    }
}
