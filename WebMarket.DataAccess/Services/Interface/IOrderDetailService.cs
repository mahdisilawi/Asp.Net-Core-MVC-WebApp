using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
	public interface IOrderDetailService
	{
		void Add(OrderDetails entity);
		IEnumerable<OrderDetails> GetAll();
		OrderDetails GetFirstOrDefault(Expression<Func<OrderDetails, bool>> filter);
		void Remove(OrderDetails entity);
		void RemoveRange(IEnumerable<OrderDetails> entities);
		void Update(OrderDetails orderDetails);

	}
}
