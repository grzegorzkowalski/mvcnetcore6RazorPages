using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmDB.Areas.CMS.Pages
{
    [Authorize(Roles = "Admin")]
    public class ListRolesModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;

        public ListRolesModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public List<IdentityRole> Roles { get; set; }
        public List<string> UserRoles { get; set; }

        public string Text { get; set; }
        public async Task OnGetAsync(string? text)
        {
            Roles = _roleManager.Roles.ToList();
            Text = text == null ? "" : text;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var test  = await _userManager.GetRolesAsync(user);
            UserRoles = (List<string>)test;
        }

        public void OnPost()
        {
            Roles = _roleManager.Roles.ToList();
        }
    }
}
