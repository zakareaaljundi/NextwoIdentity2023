using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NextwoIdentity2023.Data;
using NextwoIdentity2023.Models.ViewModel;

namespace NextwoIdentity2023.Controllers
{
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



        #endregion
    }
}
