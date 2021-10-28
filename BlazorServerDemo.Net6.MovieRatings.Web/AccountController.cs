using BlazorServerDemo.Net6.MovieRatings.Web.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerDemo.Net6.MovieRatings.Web
{
    public class AuthenticationController : Controller
    {
        private readonly PathService _pathService;
        public AuthenticationController(PathService pathService) : base()
        {
            _pathService = pathService;
        }

        public IActionResult SignIn(string returnUrl)
        {
            //force user to authenticate
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, "oidc");
        }
        public async Task<IActionResult> SignOutAsync(string returnUrl)
        {
            await HttpContext.SignOutAsync("oidc");
            await HttpContext.SignOutAsync("Cookies");
            return Redirect("~/");



            //return Redirect($"{_pathService.IdentityUrl}connect/endsession?id_token_hint={""}&post_logout_redirect_uri={"/"}&state=");
        }
    }
}
