using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmDB.Areas.CMS.Pages
{
    public class ListRolesModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ListRolesModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public List<IdentityRole> Roles { get; set; }

        public string Text { get; set; }
        public void OnGet(string? text)
        {
            Roles = _roleManager.Roles.ToList();
            Text = text == null ? "" : text;
        }

        public void OnPost()
        {
            Roles = _roleManager.Roles.ToList();
        }
    }
}
