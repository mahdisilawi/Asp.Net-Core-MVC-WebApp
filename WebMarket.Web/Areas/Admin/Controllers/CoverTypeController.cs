using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Services;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.Web.Controllers
{
    [Area("Admin")]
    public class CoverTypeController: Controller
    {
        private readonly ICoverTypeService _coverTypeService;

        public CoverTypeController(ICoverTypeService coverTypeService)
        {
            _coverTypeService = coverTypeService;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> coverTypeList = _coverTypeService.GetAll();
            return View(coverTypeList);
        }

        //Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Create
        [HttpPost]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _coverTypeService.Add(obj);
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
            var coverTypeFromDb = _coverTypeService.GetFirstOrDefault(u => u.Id == id);
            if (coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);
        }

        //Post for Edit
        [HttpPost]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _coverTypeService.Update(obj);
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
            var coverTypeFromDb = _coverTypeService.GetFirstOrDefault(u => u.Id == id);
            if (coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);
        }

        //Post for Delete
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _coverTypeService.GetFirstOrDefault(u => u.Id == id);
            _coverTypeService.Remove(obj);
            return RedirectToAction("Index");
        }
    }
}
