using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.Web.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class HomeController : Controller
	{
		private readonly IProductService _productService;
		private readonly IShoppingCartService _shoppingCartService;

		public HomeController(IProductService productService, IShoppingCartService shoppingCartService)
		{
			_productService = productService;
			_shoppingCartService = shoppingCartService;
		}
		public IActionResult Index()
		{
			IEnumerable<Product> products = _productService.GetAll();
			return View(products);
		}

		[HttpGet]
		public IActionResult ProductDetails(int productId)
		{
			ShoppingCart shoppingCart = new ShoppingCart
			{
				Product = _productService.GetFirstOrDefault(p => p.Id == productId),
				ProductId = productId,
				Count = 1
			};
			return View(shoppingCart);

		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public IActionResult ProductDetails(ShoppingCart shoppingCart)
		{
			var claimIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
			shoppingCart.ApplicationUserId = claim.Value;

			ShoppingCart cartFromDb = _shoppingCartService.GetFirstOrDefault(x =>
			x.ApplicationUserId == claim.Value && x.ProductId == shoppingCart.ProductId);

			if (cartFromDb == null)
			{
				_shoppingCartService.Add(shoppingCart);
			}
			else
			{
				_shoppingCartService.IncrementCount(cartFromDb, shoppingCart.Count);
			}


			return RedirectToAction("Index");

		}
	}
}
