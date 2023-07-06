using Librum.DataAccess.Data;
using Librum.DataAccess.Repository;
using Librum.DataAccess.Repository.IRepository;
using Librum.Models;
using Librum.Models.ViewModels;
using Librum.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace CarpeLibrum.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class SchoolController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SchoolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<School> objProdList = _unitOfWork.SchoolRepository.GetAll().ToList();
            
            return View(objProdList); 
        }

        public IActionResult Create()
        {
            return View(new School()); 
        }

        [HttpPost]
        public IActionResult Create(School c) 
        {

            if (ModelState.IsValid)
            {
                
                _unitOfWork.SchoolRepository.Add(c);
                _unitOfWork.Save();
                TempData["success"] = "School created successfully!";
                return RedirectToAction("index");
            }

                return View(c);
            
        }

        public IActionResult Edit(int? id)
        {
            if(id==0||id==null)
            {
                return NotFound();
            }
            School schoolFromDb = _unitOfWork.SchoolRepository.Get(u => u.Id == id);
            
            if (schoolFromDb == null)
            {
                return NotFound();
            }
            return View(schoolFromDb);
        }

        [HttpPost]
        public IActionResult Edit(School c)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.SchoolRepository.Update(c);
                _unitOfWork.Save();
                TempData["success"] = "School updated successfully!";
                return RedirectToAction("index");
            }
                return View(c);

        }

        //public IActionResult Upsert(int? id)
        //{
        //    //ViewBag.CategoryList = CategoryList;
        //    ProductViewModel pvm = new()
        //    {
        //        CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
        //        {
        //            Text = u.Name,
        //            Value = u.Id.ToString()
        //        }),
        //        Product = new Product()
        //    };
        //    if (id == null||id==0) // this means its a create method
        //    {
        //        return View(pvm);
        //    }
        //    else //edit functionality
        //    {
        //        pvm.Product = _unitOfWork.ProductRepository.Get(u => u.Id == id);
        //        return View(pvm);
        //    }
            
        //}
        //[HttpPost]
        //public IActionResult Upsert(ProductViewModel pvm, IFormFile? file)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string wwwRootPath = _webHostEnvironment.WebRootPath;
        //        if (file != null) 
        //        {
        //            string fileName = Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
        //            string productPath = Path.Combine(wwwRootPath, @"images\product");
        //            using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
        //            {
        //                file.CopyTo(fileStream);
        //            }
        //            pvm.Product.ImageUrl = @"images\product\" + fileName;
        //        }

        //        _unitOfWork.ProductRepository.Add(pvm.Product);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product created successfully!";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        pvm.CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
        //        {
        //            Text = u.Name,
        //            Value = u.Id.ToString()
        //        });
        //    }
        //    return View(pvm);
        //}
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Product productFromDb = _unitOfWork.ProductRepository.Get(c => c.Id == id);
        //    if (productFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productFromDb);
        //}
        //[HttpPost]
        //public IActionResult Edit(Product c)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.ProductRepository.Update(c);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product updated successfully!";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            School c = _unitOfWork.SchoolRepository.Get(c => c.Id == id);
            if (c == null)
            {
                return NotFound();
            }
            return View(c);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            School c = _unitOfWork.SchoolRepository.Get(p => p.Id == id);
            if (c == null)
            {
                TempData["error"] = "Error while deleting";
                return NotFound();
            }
            _unitOfWork.SchoolRepository.Delete(c);
            _unitOfWork.Save();
            TempData["success"] = "School deleted successfully!";
            return RedirectToAction("Index");

        }


        #region API calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProdList = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objProdList });
        }

        #endregion
    }
}
