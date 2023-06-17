using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICompanyService
    {
         void Add(Company entity);
         IEnumerable<Company> GetAll();
         Company GetFirstOrDefault(Expression<Func<Company, bool>> filter);
         void Remove(Company entity);
         void RemoveRange(IEnumerable<Company> entities);
         void Update(Company company);

    }
}
