using System.Linq.Expressions;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
    public class OrderDetailService :IOrderDetailService
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(OrderDetails entity)
        {
            _db.OrderDetails.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            IQueryable<OrderDetails> query = _db.OrderDetails;
            return query;
            
        }

        public OrderDetails GetFirstOrDefault(Expression<Func<OrderDetails, bool>> filter)
        {
            IQueryable<OrderDetails> query = _db.OrderDetails;
            query = query.Where(filter);
            return query.FirstOrDefault();
            
        }

        public void Remove(OrderDetails entity)
        {
            _db.OrderDetails.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<OrderDetails> entities)
        {
            _db.OrderDetails.RemoveRange(entities);
            _db.SaveChanges();
        }
        public void Update(OrderDetails orderDetails)
        {
            _db.OrderDetails.Update(orderDetails);
            _db.SaveChanges();
        }
    }
}
