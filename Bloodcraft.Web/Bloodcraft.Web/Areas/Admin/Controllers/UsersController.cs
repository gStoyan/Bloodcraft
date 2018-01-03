namespace Bloodcraft.Web.Areas.Admin.Controllers
{
    using Bloodcraft.Data.Models;
    using Bloodcraft.Services.Admin;
    using Bloodcraft.Web.Areas.Admin.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersController : AdminBaseController
    {
        private IAdminUsersService usersService;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UsersController(IAdminUsersService usersService,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int page = 1)
          =>
            View(new AdminListingViewModel
            {
                AllUsers = await this.usersService.AllAsync(page),
                TotalUsers = await this.usersService.TotalUsersAsync(),
                CurrentPage = page,
            });

        [Route("admin/users/details/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(string id)
        {
            var result = await this.usersService.DetailsAsync(id);

            return View(new AdminUserDetailsViewModel
            {
                Username = result.Username,
                Castles = result.Castles
            });
        }
        

        public async Task<IActionResult> Delete(string id)
        {
            await this.usersService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> ChangeRole(string id)
        {
            var rolesSelectListItems = await this.roleManager
                 .Roles
                 .Select(r => new SelectListItem
                 {
                     Text = r.Name,
                     Value = r.Name
                 })
                 .ToListAsync();

            return View(rolesSelectListItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(string id, string role)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var roleExists = await this.roleManager.RoleExistsAsync(role);

            if (user==null || !roleExists)
            {
                return NotFound();
            }

            await this.userManager.AddToRoleAsync(user, role);

            TempData["SucceessMessage"] = $"User{user.UserName} added to role {role}!";

            return RedirectToAction(nameof(Index));
        }
    }
}
