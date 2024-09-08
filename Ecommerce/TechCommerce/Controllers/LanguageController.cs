using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace TechCommerce.Controllers;

public class LanguageController : Controller
{
    // GET
    public IActionResult SetLanguage(string culture, string path)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

        return path == null ? LocalRedirect("/") : LocalRedirect(path);
    }
}