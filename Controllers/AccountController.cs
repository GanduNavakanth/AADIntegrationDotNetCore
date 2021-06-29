using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using Microsoft.Identity;
using System.Linq;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Options;

namespace SampleAADDotnetCore.Controllers
{

    [NonController]
    [AllowAnonymous]
    [Area("MicrosoftIdentity")]
    [Route("[area]/[controller]/[action]")]
    public class AccountController : Controller
    {

        private readonly IOptionsMonitor<MicrosoftIdentityOptions> _optionsMonitor;

        
        public AccountController(IOptionsMonitor<MicrosoftIdentityOptions> microsoftIdentityOptionsMonitor)
        {
            _optionsMonitor = microsoftIdentityOptionsMonitor;
        }

        
        [HttpGet("{scheme?}")]
        public IActionResult SignOut(
            [FromRoute] string scheme)
        {
            if (AppServicesAuthenticationInformation.IsAppServicesAadAuthenticationEnabled)
            {
                return LocalRedirect(AppServicesAuthenticationInformation.LogoutUrl);
            }
            else
            {
                scheme ??= OpenIdConnectDefaults.AuthenticationScheme;
                var callbackUrl = Url.Page("/Account/SignOut", pageHandler: null, values: null, protocol: Request.Scheme);
                return SignOut(
                     new AuthenticationProperties
                     {
                         RedirectUri = callbackUrl,
                     },
                     CookieAuthenticationDefaults.AuthenticationScheme,
                     scheme);
            }
        }

       
    }
}
