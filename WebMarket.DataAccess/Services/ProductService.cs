using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;
using WebMarket.Models.ViewModels;

namespace WebMarket.DataAccess.Services
{
    public class ProductService : IProductService
    {

        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(ProductViewModel entity)
        {
            _db.Products.Add(entity.Product);
            _db.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            IQueryable<Product> query = _db.Products.Include(x => x.Category).Include(x => x.CoverType);
            return query;

        }

        public Product GetFirstOrDefault(Expression<Func<Product, bool>> filter)
        {
            IQueryable<Product> query = _db.Products;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(Product entity)
        {
            _db.Products.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            _db.Products.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void Update(Product obj)
        {
            var objProduct = _db.Products.FirstOrDefault(x => x.Id == obj.Id);
            if (objProduct != null)
            {
                objProduct.Title = obj.Title;
                objProduct.Description = obj.Description;
                objProduct.ShortDescription = obj.ShortDescription;
                objProduct.Category = obj.Category;
                objProduct.ImageAlt = obj.ImageAlt;
                if(obj.ImageUrl != null)
                {
                    objProduct.ImageUrl = obj.ImageUrl;
                }               
                objProduct.ImageTitle = obj.ImageTitle;
                objProduct.Price = obj.Price;
                objProduct.Price50 = obj.Price50;
                objProduct.Price100 = obj.Price100;
                objProduct.Author = obj.Author;
                objProduct.ISBN = obj.ISBN;
                objProduct.CategoryId = obj.CategoryId;
                objProduct.CoverTypeId = obj.CoverTypeId;
                objProduct.ListPrice = obj.ListPrice;

            }

            _db.SaveChanges();
        }
    }
}

