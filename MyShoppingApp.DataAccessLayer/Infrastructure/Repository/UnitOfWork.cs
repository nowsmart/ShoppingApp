using MyShoppingApp.DataAccessLayer.Data;
using MyShoppingApp.DataAccessLayer.Infrastructure.IRepository;

namespace MyShoppingApp.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICartRepository Cart { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IApplicationUser ApplicationUser { get; private set; }
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
            Cart = new CartRepository(context);
            OrderHeader = new OrderHeaderRepository(context);
            OrderDetail = new OrderDetailRepository(context);
            ApplicationUser = new ApplicationUserRepository(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
