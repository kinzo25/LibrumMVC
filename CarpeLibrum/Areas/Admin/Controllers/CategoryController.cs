using Librum.DataAccess.Data;
using Librum.DataAccess.Repository;
using Librum.DataAccess.Repository.IRepository;
using Librum.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarpeLibrum.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCatList = _unitOfWork.CategoryRepository.GetAll().ToList();
            return View(objCatList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category c)
        {
            if (c.Name.ToLower() == c.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display order cannot exactly match name.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(c);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _unitOfWork.CategoryRepository.Get(c => c.Id == id);
            if (categoryFromDb == null)
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
                _unitOfWork.CategoryRepository.Update(c);
                _unitOfWork.Save();
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
            Category categoryFromDb = _unitOfWork.CategoryRepository.Get(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category c = _unitOfWork.CategoryRepository.Get(c => c.Id == id);
            if (c == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Delete(c);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");

        }

    }
}
