using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspRolesRazor.Pages.Admin;

public class Index : PageModel
{
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnGetEdit(string id)
    {
        return RedirectToPage("/Admin/EditUser", new { id = id });
    }

    public async Task OnGetDelete(string id)
    {
        
    }
}