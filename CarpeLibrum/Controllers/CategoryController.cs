using CarpeLibrum.Data;
using CarpeLibrum.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarpeLibrum.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCatList = _db.Categories.ToList();
            return View(objCatList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category c)
        {
            if(c.Name.ToLower() == c.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display order cannot exactly match name.");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(c);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
            if(categoryFromDb==null) 
            { 
                return NotFound(); 
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category c)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(c);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category c = _db.Categories.Find(id);
            if(c== null)
            {
                return NotFound();
            }
            _db.Categories.Remove(c);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
            
        }

    }
}
