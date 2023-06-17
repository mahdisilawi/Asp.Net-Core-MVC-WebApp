using System.Linq.Expressions;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
    public class CompanyService :ICompanyService
    {
        private readonly ApplicationDbContext _db;
        public CompanyService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Company entity)
        {
            _db.Companies.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Company> GetAll()
        {
            IQueryable<Company> query = _db.Companies;
            return query;

        }

        public Company GetFirstOrDefault(Expression<Func<Company, bool>> filter)
        {
            IQueryable<Company> query = _db.Companies;
            query = query.Where(filter);
            return query.FirstOrDefault();

        }

        public void Remove(Company entity)
        {
            _db.Companies.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Company> entities)
        {
            _db.Companies.RemoveRange(entities);
            _db.SaveChanges();
        }
        public void Update(Company company)
        {
            _db.Companies.Update(company);
            _db.SaveChanges();
        }
    }
}

