using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Dynamic.Core;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models.ViewModels;

namespace WebMarket.Web.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductService productService, ICategoryService categoryService,
            ICoverTypeService coverTypeService, IWebHostEnvironment hostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _coverTypeService = coverTypeService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get For UpSert
        public IActionResult Upsert(int? id)
        {
            ProductViewModel productViewModel = new()
            {
                Product = new(),
                CategoryList = _categoryService.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

                CoverTypeList = _coverTypeService.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })

            };

            if (id == null || id == 0)
            {
                //Create
                //ViewBag.CategoryList = CategoryList;
                //ViewBag.CoverTypeList = CoverTypeList;
                return View(productViewModel);
            }
            else
            {
                //Update
                productViewModel.Product = _productService.GetFirstOrDefault(x => x.Id == id);
                return View(productViewModel);
            }
            return View(productViewModel);
        }

        //Post for UpSert
        [HttpPost]
        public IActionResult Upsert(ProductViewModel obj, IFormFile? file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extensions = Path.GetExtension(file.FileName);

                    //DeleteOldImage
                    if (obj.Product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extensions), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    obj.Product.ImageUrl =  fileName + extensions;
                }
                if (obj.Product.Id == 0) _productService.Add(obj);
                else _productService.Update(obj.Product);

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get For Delete
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var productFromDb = _productService.GetFirstOrDefault(u => u.Id == id);
        //    if (productFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productFromDb);
        //}

        ////Post for Delete
        //[HttpPost]
        //public IActionResult DeletePost(int? id)
        //{
        //    var obj = _productService.GetFirstOrDefault(u => u.Id == id);
        //    _productService.Remove(obj);
        //    return RedirectToAction("Index");
        //}

        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _productService.GetAll();
            return Json(new { data = productList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _productService.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "خطادرحذف" });
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _productService.Remove(obj);
            return Json(new { success = true, message = "حذف موفقیت آمیز" });
        }
        #endregion

    }
}
