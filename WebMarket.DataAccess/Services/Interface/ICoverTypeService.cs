using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICoverTypeService
    {
         void Add(CoverType entity);
         IEnumerable<CoverType> GetAll();
         CoverType GetFirstOrDefault(Expression<Func<CoverType, bool>> filter);
         void Remove(CoverType entity);
         void RemoveRange(IEnumerable<CoverType> entities);
         void Update(CoverType coverType);

    }
}
