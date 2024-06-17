using FahasaStoreAdminApp.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FahasaStoreAdminApp.Helpers;

namespace FahasaStoreAdminApp.Filters
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var accessToken = context.HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(accessToken))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            var jwtTokenDecoder = (IJwtTokenDecoder?)context.HttpContext.RequestServices.GetService(typeof(IJwtTokenDecoder));
            if (jwtTokenDecoder == null)
            {
                context.Result = new RedirectToActionResult("Error", "Home", new { message = "Service error" });
                return;
            }

            try
            {
                var userClaims = jwtTokenDecoder.DecodeToken(accessToken).Claims;
                var roles = userClaims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

                if (!_roles.Any(role => roles.Contains(role)))
                {
                    context.Result = new RedirectToActionResult("AccessDenied", "Error", null);
                    return;
                }
            }
            catch (Exception)
            {
                context.Result = new RedirectToActionResult("Error", "Home", new { message = "Token error" });
                return;
            }
        }
    }


}
