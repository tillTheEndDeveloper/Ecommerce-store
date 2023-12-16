using ePhoneCourseWork.Data.Cart;
using ePhoneCourseWork.Data.Services;
using ePhoneCourseWork.Data.Static;
using ePhoneCourseWork.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ePhoneCourseWork.Controllers
{
    [Authorize]
    public class OrdersController : Controller
	{
		private readonly IProductsService _productsService;
		private readonly ShoppingCart _shoppingCart;
		private readonly IOrdersService _ordersService;

		public OrdersController(IProductsService productsService, ShoppingCart shoppingCart, IOrdersService ordersService)
		{
			_productsService = productsService;
			_shoppingCart = shoppingCart;
			_ordersService = ordersService;
		}

		public IActionResult Index()
		{
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			string userRole = User.FindFirstValue(ClaimTypes.Role);
			var orders = _ordersService.GetOrdersByUserIdAndRole(userId,userRole);
			return View(orders);
		}

		public IActionResult ShoppingCart()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;
			var response = new ShoppingCartVM()
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};
			return View(response);
		}

		public IActionResult AddItemToShoppingCart(int id)
		{
			var item = _productsService.GetProductById(id);
			if (item != null)
			{
				_shoppingCart.AddItemToCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));
		}

		public IActionResult RemoveItemFromShoppingCart(int id)
		{
			var item = _productsService.GetProductById(id);
			if (item != null)
			{
				_shoppingCart.RemoveItemFromCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));
		}

		public IActionResult CompleteOrder()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

			_ordersService.StoreOrder(items, userId, userEmailAddress);
			_shoppingCart.ClearShoppingCart();
			return View("OrderCompleted");
		}
	}

}