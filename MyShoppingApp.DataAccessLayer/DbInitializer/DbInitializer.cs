using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyShoppingApp.CommenHelper;
using MyShoppingApp.DataAccessLayer.Data;
using MyShoppingApp.Models;

namespace MyShoppingApp.DataAccessLayer.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDBContext _context;
        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying migrations: {ex.Message}"); 
                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSiteRole.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_User)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_Employee)).GetAwaiter().GetResult();
                var userName = Environment.GetEnvironmentVariable("EmailSettings__SenderEmail");
                var password = Environment.GetEnvironmentVariable("EmailSettings__Password");
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = userName,
                    Email = userName,
                    Name = "Admin",
                    PhoneNumber = "1234567890",
                    Address = "Brandreth Road",
                    City = "Lahore",
                    State = "Punjab",
                    PinCode = "54500"

                }, password).GetAwaiter().GetResult();
                ApplicationUser user = _context.Users.FirstOrDefault(x => x.Email == userName);
                _userManager.AddToRoleAsync(user, WebSiteRole.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
