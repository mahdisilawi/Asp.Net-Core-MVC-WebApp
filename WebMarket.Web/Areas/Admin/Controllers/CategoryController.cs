using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess;
using WebMarket.DataAccess.Services;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.Web.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _categoryService.GetAll();
            return View(categoryList);
        }

        //Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Create
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "مقدار نام با مفدار ترتیب نمایش تباید یکی باشند!");
            }

            if (ModelState.IsValid)
            {
                _categoryService.Add(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get For Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _categoryService.GetFirstOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post for Edit
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "مقدار نام با مفدار ترتیب نمایش تباید یکی باشند!");
            }

            if (ModelState.IsValid)
            {
                _categoryService.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get For Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _categoryService.GetFirstOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post for Delete
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _categoryService.GetFirstOrDefault(u => u.Id == id);
            _categoryService.Remove(obj);
            return RedirectToAction("Index");
        }
    }
}
