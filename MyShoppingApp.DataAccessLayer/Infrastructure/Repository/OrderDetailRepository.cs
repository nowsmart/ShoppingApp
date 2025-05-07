using MyShoppingApp.DataAccessLayer.Data;
using MyShoppingApp.DataAccessLayer.Infrastructure.IRepository;
using MyShoppingApp.Models;

namespace MyShoppingApp.DataAccessLayer.Infrastructure.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDBContext _context;
        public OrderDetailRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public void Update(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);

        }
    }
}
