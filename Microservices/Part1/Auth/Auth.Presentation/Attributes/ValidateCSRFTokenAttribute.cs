using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auth.Presentation.Attributes;


using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class ValidateCsrfTokenAttribute : TypeFilterAttribute
{
    public ValidateCsrfTokenAttribute() : base(typeof(CsrfTokenActionFilter))
    {
    }
}