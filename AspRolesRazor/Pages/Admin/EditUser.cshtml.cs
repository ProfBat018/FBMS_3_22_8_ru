using System.Security.Claims;
using AspRolesRazor.Areas.Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspRolesRazor.Pages.Admin;

public class EditUser : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    public AppUser User { get; set; }

    public EditUser(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    
    public async Task OnGet(string id)
    {
        User = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        
        TempData["UserId"] = User.Id;
    }

    public async Task<IActionResult> OnPost(string userName)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == TempData["UserId"].ToString());

        user.UserName = userName;
        
        var res = await _userManager.UpdateAsync(user);

        if (res.Succeeded)
        {
            return RedirectToPage("/Index");
        }

        return RedirectToPage("Error", new { message = res.Errors.ToString() });
    }
}