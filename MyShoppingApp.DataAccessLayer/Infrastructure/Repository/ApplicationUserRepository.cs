using MyShoppingApp.DataAccessLayer.Data;
using MyShoppingApp.DataAccessLayer.Infrastructure.IRepository;
using MyShoppingApp.Models;

namespace MyShoppingApp.DataAccessLayer.Infrastructure.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUser
    {
        private ApplicationDBContext _context;
        public ApplicationUserRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
