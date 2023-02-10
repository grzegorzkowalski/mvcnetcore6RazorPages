using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmDB.Areas.CMS.Pages
{
    [Authorize(Roles = "Admin")]
    public class AddToRoleModel : PageModel
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;

        public AddToRoleModel(RoleManager<IdentityRole> rolManager,
            UserManager<IdentityUser> userManager)
        {
            _roleManager = rolManager;
            _userManager = userManager;

        }
        public List<IdentityRole> Roles { get; set; }
        public List<IdentityUser> Users { get; set; }

        [FromForm(Name = "UserID")]
        public string UserID { get; set; }
        [FromForm(Name = "RoleID")]
        public string RoleID { get; set; }
        public void OnGet()
        {
            Roles = _roleManager.Roles.ToList();
            Users = _userManager.Users.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var role = await _roleManager.FindByIdAsync(RoleID);
            var user = await _userManager.FindByIdAsync(UserID);

            if (role != null && user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    return RedirectToPage("/ListRoles", new { text = $"{user.UserName} zosta³ doddany poprawnie do roli {role.Name}" });
                }
                else
                {
                    Roles = _roleManager.Roles.ToList();
                    Users = _userManager.Users.ToList();
                }
            }
            return Page();
        }


    }
}
