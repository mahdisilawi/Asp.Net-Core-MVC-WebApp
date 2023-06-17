using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
	public interface IOrderHeaderService
	{
		void Add(OrderHeader entity);
		IEnumerable<OrderHeader> GetAll();
		OrderHeader GetFirstOrDefault(Expression<Func<OrderHeader, bool>> filter);
		void Remove(OrderHeader entity);
		void RemoveRange(IEnumerable<OrderHeader> entities);
		void Update(OrderHeader orderHeader);
		void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);

	}
}
