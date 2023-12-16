using ePhoneCourseWork.Data.Base;
using ePhoneCourseWork.Models;
using System.Linq;

namespace ePhoneCourseWork.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Product GetProductById(int id)
        {
            var movieDetails = _context.Products.FirstOrDefault(n=>n.Id==id);
            return movieDetails;
        }

        //public void UpdateProduct(Product product)
        //{
        //    var dbProduct = _context.Products.FirstOrDefault(n => n.Id == product.Id);
        //    if (dbProduct != null)
        //    {

        //        dbProduct.Name = product.Name;
        //        dbProduct.Description = product.Description;
        //        dbProduct.Price = product.Price;
        //        dbProduct.Image = product.Image;
        //        dbProduct.Color = product.Color;
        //        _context.SaveChanges();
        //    }
        //    _context.SaveChanges();
        //}
    }
}
