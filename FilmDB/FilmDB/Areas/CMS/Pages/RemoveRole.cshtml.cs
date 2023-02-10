using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmDB.Areas.CMS.Pages
{
    public class RemoveRoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        [BindProperty]
        public IdentityRole Role { get; set; }
        public RemoveRoleModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task OnGetAsync(string id)
        {
            Role = await _roleManager.FindByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(IdentityRole role)
        {
            var roleToDelete = await _roleManager.FindByIdAsync(role.Id);
            roleToDelete.Name = role.Name;
            var result = await _roleManager.DeleteAsync(roleToDelete);
            if (result.Succeeded)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
