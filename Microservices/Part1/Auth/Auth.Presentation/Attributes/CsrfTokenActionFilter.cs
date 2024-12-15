using Microsoft.IdentityModel.Tokens;

namespace Auth.Presentation.Attributes;

    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public class CsrfTokenActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<CsrfTokenActionFilter> _logger;

        public CsrfTokenActionFilter(ILogger<CsrfTokenActionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var csrfToken = context.HttpContext.Request.Headers["X-CSRF-Token"].FirstOrDefault();
            var decodedCsrfToken = Uri.UnescapeDataString(csrfToken);
            var expectedToken = context.HttpContext.Request.Cookies["X-CSRF-Token"];
            
            if (decodedCsrfToken != expectedToken)
            {

                _logger.LogWarning("Invalid CSRF Token received.");
                

                context.Result = new UnauthorizedObjectResult("Invalid CSRF token");


                throw new SecurityTokenExpiredException("Invalid CSRF token");


                return;
            }


            await next();
        }
    }
