using MyShoppingApp.Models;

namespace MyShoppingApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        void Update(OrderDetail orderDetail);
    }
}
