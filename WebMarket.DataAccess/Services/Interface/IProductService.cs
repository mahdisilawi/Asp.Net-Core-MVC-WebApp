using System.Linq.Expressions;
using WebMarket.Models;
using WebMarket.Models.ViewModels;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface IProductService
    {
         void Add(ProductViewModel entity);
         IEnumerable<Product> GetAll();
         Product GetFirstOrDefault(Expression<Func<Product, bool>> filter);
         void Remove(Product entity);
         void RemoveRange(IEnumerable<Product> entities);
         void Update(Product product);
    }
}
