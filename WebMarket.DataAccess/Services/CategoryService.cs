using System.Linq.Expressions;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
    public class CategoryService :ICategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Category entity)
        {
            _db.Categories.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            IQueryable<Category> query = _db.Categories;
            return query;
            
        }

        public Category GetFirstOrDefault(Expression<Func<Category, bool>> filter)
        {
            IQueryable<Category> query = _db.Categories;
            query = query.Where(filter);
            return query.FirstOrDefault();
            
        }

        public void Remove(Category entity)
        {
            _db.Categories.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            _db.Categories.RemoveRange(entities);
            _db.SaveChanges();
        }
        public void Update(Category coverType)
        {
            _db.Categories.Update(coverType);
            _db.SaveChanges();
        }
    }
}
