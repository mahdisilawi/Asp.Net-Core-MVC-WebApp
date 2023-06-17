using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess;
using WebMarket.DataAccess.Services;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.Web.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companies = _companyService.GetAll();
            return View(companies);
        }

        //Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Create
        [HttpPost]
        public IActionResult Create(Company obj)
        {

            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "مقدار نام با مفدار ترتیب نمایش تباید یکی باشند!");
            //}

            if (ModelState.IsValid)
            {
                _companyService.Add(obj);
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
            var companyFromDb = _companyService.GetFirstOrDefault(u => u.Id == id);
            if (companyFromDb == null)
            {
                return NotFound();
            }
            return View(companyFromDb);
        }

        //Post for Edit
        [HttpPost]
        public IActionResult Edit(Company obj)
        {

            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "مقدار نام با مفدار ترتیب نمایش تباید یکی باشند!");
            //}

            if (ModelState.IsValid)
            {
                _companyService.Update(obj);
                TempData["success"] = "کمپانی با موفقیت ویرایش شد!";
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
            var companyFromDb = _companyService.GetFirstOrDefault(u => u.Id == id);
            if (companyFromDb == null)
            {
                return NotFound();
            }
            return View(companyFromDb);
        }

        //Post for Delete
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _companyService.GetFirstOrDefault(u => u.Id == id);
            _companyService.Remove(obj);
            return RedirectToAction("Index");
        }
    }
}
