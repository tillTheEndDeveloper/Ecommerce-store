using ePhoneCourseWork.Data;
using ePhoneCourseWork.Data.Services;
using ePhoneCourseWork.Data.Static;
using ePhoneCourseWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ePhoneCourseWork.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var allProducts = _service.GetAll();
            return View(allProducts);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var productDetail = _service.GetProductById(id);
            return View(productDetail);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name,Image,Description,Color,Price")]Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _service.Add(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var productDetails = _service.GetById(id);
            if (productDetails == null)
            {
                return View("NotFound");
            }
            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var productDetails = _service.GetById(id);
            if (productDetails == null)
            {
                return View("NotFound");
            }
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public IActionResult Filter(string searchString)
        {
            var allProducts = _service.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filterResult = allProducts.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filterResult);
            }
            return View("Index",allProducts);
        }

        public IActionResult Edit(int id)
        {
            var productDetails = _service.GetById(id);
            if (productDetails == null)
            {
                return View("NotFound");
            }
            return View(productDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Image,Description,Color,Price")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            if (id == product.Id)
            {
                _service.Update(id, product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
