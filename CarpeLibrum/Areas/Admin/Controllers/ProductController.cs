using Librum.DataAccess.Data;
using Librum.DataAccess.Repository;
using Librum.DataAccess.Repository.IRepository;
using Librum.Models;
using Librum.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Collections.Generic;


namespace CarpeLibrum.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> objProdList = _unitOfWork.ProductRepository.GetAll().ToList();
            
            return View(objProdList); 
        }

        public IActionResult Create()
        {
            ProductViewModel pvm = new()
            {
                CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            return View(pvm); 
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel pvm, IFormFile file) 
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Add(pvm.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully!";
                return RedirectToAction("index");
            }
            else
            {
                pvm.CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                
                return View(pvm);
            }
            
        }

        public IActionResult Edit(int? id)
        {
            if(id==0||id==null)
            {
                return NotFound();
            }
            Product productFromDb = _unitOfWork.ProductRepository.Get(u => u.Id == id);
            ProductViewModel pvm = new()
            {
                CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = productFromDb
            };
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(pvm);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel pvm, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Update(pvm.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully!";
                return RedirectToAction("index");
            }
            
            {
                pvm.CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                return View(pvm);
            }
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
            Product productFromDb = _unitOfWork.ProductRepository.Get(c => c.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product c = _unitOfWork.ProductRepository.Get(c => c.Id == id);
            if (c == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepository.Delete(c);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully!";
            return RedirectToAction("Index");

        }

    }
}
