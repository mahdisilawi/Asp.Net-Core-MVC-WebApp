using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public  interface IShoppingCartService
    {
        void Add(ShoppingCart entity);
        IEnumerable<ShoppingCart> GetAll(string? id);
        ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter);
        void Remove(ShoppingCart entity);
        void RemoveRange(IEnumerable<ShoppingCart> entities);
        void Update(ShoppingCart shoppingCart);
        int IncrementCount(ShoppingCart shoppingCart, int count);
        int DecrementCount(ShoppingCart shoppingCart, int count);

    }
}
