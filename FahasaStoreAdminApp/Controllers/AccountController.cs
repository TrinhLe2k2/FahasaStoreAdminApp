using FahasaStoreAdminApp.Filters;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace FahasaStoreAdminApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IJwtTokenDecoder _jwtTokenDecoder;

        public AccountController(IAccountService accountService, IJwtTokenDecoder jwtTokenDecoder, IUserService userService)
        {
            _accountService = accountService;
            _jwtTokenDecoder = jwtTokenDecoder;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var accessToken = await _accountService.LogInAsync(model);
                var userClaims = _jwtTokenDecoder.DecodeToken(accessToken).Claims;
                //var roles = userClaims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
                //var hasRole = roles.Any(role => role == AppRole.Customer);
                //if (!hasRole)
                //{
                //    return RedirectToAction("Error", "Error", new { ErrorCode = 401 });
                //}
                var UserId = userClaims.FirstOrDefault(c => c.Type == "UserId")?.Value;
                HttpContext.Session.SetString("JWToken", accessToken);
                HttpContext.Session.SetString("UserId", UserId);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Lỗi token đăng nhập.";
                return RedirectToAction("Login", "Account");
            }
            var result = await _accountService.LogOutAsync(accessToken);

            if (result)
            {
                HttpContext.Session.Remove("JWToken");
                HttpContext.Session.Remove("FullName");
                HttpContext.Session.Remove("Avatar");

                TempData["SuccessMessage"] = "Bạn đã đăng xuất thành công.";
                return RedirectToAction("Login", "Account");
            }
            else
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi đăng xuất.";
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserLogin()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var user = await _userService.GetUserByIdAsync(userId);
            return Json(user);
        }
    }
}
