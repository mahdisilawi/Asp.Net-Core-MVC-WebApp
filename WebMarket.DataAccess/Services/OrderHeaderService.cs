using System.Linq.Expressions;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
	public class OrderHeaderService : IOrderHeaderService
	{
		private readonly ApplicationDbContext _db;
		public OrderHeaderService(ApplicationDbContext db)
		{
			_db = db;
		}
		public void Add(OrderHeader entity)
		{
			_db.OrderHeaders.Add(entity);
			_db.SaveChanges();
		}

		public IEnumerable<OrderHeader> GetAll()
		{
			IQueryable<OrderHeader> query = _db.OrderHeaders;
			return query;

		}

		public OrderHeader GetFirstOrDefault(Expression<Func<OrderHeader, bool>> filter)
		{
			IQueryable<OrderHeader> query = _db.OrderHeaders;
			query = query.Where(filter);
			return query.FirstOrDefault();

		}

		public void Remove(OrderHeader entity)
		{
			_db.OrderHeaders.Remove(entity);
			_db.SaveChanges();
		}

		public void RemoveRange(IEnumerable<OrderHeader> entities)
		{
			_db.OrderHeaders.RemoveRange(entities);
			_db.SaveChanges();
		}
		public void Update(OrderHeader orderHeader)
		{
			_db.OrderHeaders.Update(orderHeader);
			_db.SaveChanges();
		}

		public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
		{
			var orderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);

			if (orderFromDb != null)
			{
				orderFromDb.OrderStatus = orderStatus;
				if (paymentStatus != null)
				{
					orderFromDb.PaymentStatus = paymentStatus;
				}
			}

		}
	}
}
