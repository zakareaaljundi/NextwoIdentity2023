using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextwoIdentity2023.Data;
using NextwoIdentity2023.Models.ViewModel;

namespace NextwoIdentity2023.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        #region Configuration

        private NextwoDbcontext db;
        public CategoryController(NextwoDbcontext _db)
        {
            db = _db;
        }

        #endregion

        #region Category

        [HttpGet]
        public async Task<IActionResult> AllCategorys()
        {
            return View(db.Categorys);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categorys.Add(category);
                db.SaveChanges();
                return RedirectToAction(nameof(AllCategorys));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllCategorys");
            }
            var data = db.Categorys.Find(id);
            if (data == null)
            {
                return RedirectToAction("AllCategorys");
            }
            ViewBag.allDept = new SelectList(db.Categorys, "CategoryId", "CategoryName");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categorys.Update(category);
                db.SaveChanges();
                return RedirectToAction("AllCategorys");
            }
            return View(category);

        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllCategorys");
            }
            var data = db.Categorys.Find(id);
            if (data == null)
            {
                return RedirectToAction("AllCategorys");
            }
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categorys.Remove(category);
                db.SaveChanges();
                return RedirectToAction("AllCategorys");
            }
            return View(category);

        }

        #endregion
    }
}
