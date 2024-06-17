using FahasaStoreAdminApp.Filters;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.CustomModels;
using FahasaStoreAdminApp.Services;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FahasaStoreAdminApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly UserLogined _userLogined;
        private readonly IJwtTokenDecoder _jwtTokenDecoder;

        public AccountController(IAccountService accountService, IJwtTokenDecoder jwtTokenDecoder, IUserService userService, UserLogined userLogined)
        {
            _accountService = accountService;
            _jwtTokenDecoder = jwtTokenDecoder;
            _userService = userService;
            _userLogined = userLogined;
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
                ModelState.AddModelError(string.Empty, "login failed. Please try again.");
                return RedirectToAction("Index", "Home");
            }
            var accessToken = await _accountService.LogInAsync(model);
            var userClaims = _jwtTokenDecoder.DecodeToken(accessToken).Claims;
            var UserId = userClaims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            var roles = userClaims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

            if (string.IsNullOrEmpty(UserId) || userClaims == null || !roles.Contains(AppRole.Admin) && !roles.Contains(AppRole.Staff)) 
            {
                TempData["ErrorMessage"] = "Bạn không có quyền truy cập.";
                return RedirectToAction("LogOut");
            }

            var currentUser = await _userService.GetByIdAsync(UserId);
            _userLogined.CurrentUser = currentUser;
            _userLogined.JWToken = accessToken;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            if (_userLogined.JWToken != null)
            {
                var result = await _accountService.LogOutAsync(_userLogined.JWToken);
                HttpContext.Session.Clear();
            }
            TempData["SuccessMessage"] = "Bạn đã đăng xuất thành công.";
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AppRole.Admin)]
        public async Task<IActionResult> AddRoleToUser(string userId, string role)
        {
            var result = await _accountService.AddRoleToUser(userId, role);
            if (result)
            {
                TempData["SuccessMessage"] = "Cập nhật thành công";
                return RedirectToAction("Index", "Users");
            }
            TempData["ErrorMessage"] = "Cập nhật thất bại";
            return RedirectToAction("Index", "Users");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AppRole.Admin)]
        public async Task<IActionResult> RemoveRoleFromUser(string userId, string role)
        {
            var result = await _accountService.RemoveRoleFromUser(userId, role);
            if (result)
            {
                TempData["SuccessMessage"] = "Cập nhật thành công";
                return RedirectToAction("Index", "Users");
            }
            TempData["ErrorMessage"] = "Cập nhật thất bại";
            return RedirectToAction("Index", "Users");
        }
    }
}
