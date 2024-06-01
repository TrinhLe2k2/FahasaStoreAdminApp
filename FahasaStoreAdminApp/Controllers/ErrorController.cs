using FahasaStoreAdminApp.Filters;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class ErrorController : Controller
    {
        [Authorize(AppRole.Customer, AppRole.Admin, AppRole.Staff)]
        [Route("Error/{statusCode}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            string errorMessage;
            int? errorCode;

            switch (statusCode)
            {
                case 401:
                    errorMessage = "Không được phép truy cập";
                    errorCode = 401; // Mã lỗi 401
                    break;
                case 404:
                    errorMessage = "Sorry, the resource you requested could not be found.";
                    errorCode = 404; // Mã lỗi 404
                    break;
                case 500:
                    errorMessage = "Sorry, something went wrong on the server.";
                    errorCode = 500; // Mã lỗi 500
                    break;
                default:
                    errorMessage = "An unexpected error occurred.";
                    errorCode = statusCode; // Sử dụng mã lỗi của trạng thái HTTP
                    break;
            }

            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorMessage = errorMessage,
                ErrorCode = errorCode // Thiết lập mã lỗi
            };

            return View(errorViewModel);
        }

        [Route("AccessDenied")]
        [Authorize(AppRole.Customer, AppRole.Admin, AppRole.Staff)]
        public IActionResult AccessDenied()
        {
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorCode = 401,
                ErrorMessage = "Bạn không có quyền truy cập vào mục này."
            };

            return View(errorViewModel);
        }
    }
}
