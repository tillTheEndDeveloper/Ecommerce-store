using ePhoneCourseWork.Data.Base;
using ePhoneCourseWork.Models;

namespace ePhoneCourseWork.Data.Services
{
    public interface IProductsService:IEntityBaseRepository<Product>
    {
        Product GetProductById(int id);
        //void UpdateProduct(Product product);
    }
}
