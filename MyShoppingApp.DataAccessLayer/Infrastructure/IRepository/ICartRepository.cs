using MyShoppingApp.Models;

namespace MyShoppingApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface ICartRepository : IRepository<Cart>
    {
        int IncrimentCartItem(Cart cart, int count);
        int DecrementCartItem(Cart cart, int count);
    }
}
