using Jungle_DataAccess;
using Jungle_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jungle_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly Jungle_DataAccess.JungleDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(JungleDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            {
                var userList = _db.Users.ToList();
                var userRole = _db.UserRoles.ToList();
                var roles = _db.Roles.ToList();


                foreach (var user in userList)
                {
                    var role = userRole.FirstOrDefault(u => u.UserId == user.Id);
                    if (role == null)
                    {
                        user.Role = "None";
                    }
                    else
                    {
                        user.Role = roles.FirstOrDefault(u => u.Id == role.RoleId).Name;
                    }
                }

                return View(userList);

            }
        }
    }
}
