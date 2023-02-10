using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmDB.Areas.CMS.Pages
{
    [Authorize]
    public class AddRoleModel : PageModel
    {
       private readonly RoleManager<IdentityRole> _roleManager;

        [BindProperty]
        public IdentityRole Role { get; set; }
       public AddRoleModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var role = _roleManager.Roles;
        }
    }
}
