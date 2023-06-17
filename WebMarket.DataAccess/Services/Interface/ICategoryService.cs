using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICategoryService
    {
         void Add(Category entity);
         IEnumerable<Category> GetAll();
         Category GetFirstOrDefault(Expression<Func<Category, bool>> filter);
         void Remove(Category entity);
         void RemoveRange(IEnumerable<Category> entities);
         void Update(Category coverType);

    }
}
