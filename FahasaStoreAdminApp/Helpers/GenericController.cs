using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Models.Response;
using FahasaStoreAdminApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
// FahasaStoreAdminApp.Models.EModels.
namespace FahasaStoreAdminApp.Helpers
{
    public abstract class GenericController<TEntity, TModel, DTO, TKey> : Controller
        where TEntity : class
        where TModel : class
        where DTO : class
        where TKey : IEquatable<TKey>
    {
        private readonly IGenericService<TEntity, TModel, DTO, TKey> _service;
        protected readonly IMapper _mapper;
        protected readonly IImageUploader _imageUploader;
        protected GenericController(IGenericService<TEntity, TModel, DTO, TKey> service, IMapper mapper, IImageUploader imageUploader)
        {
            _service = service;
            _mapper = mapper;
            _imageUploader = imageUploader;
        }
        public virtual async Task<IActionResult> Index(
            Dictionary<string, string>? filters,
            string? sortField,
            string? sortDirection,
            int page = 1,
            int size = 10)
        {
            try
            {
                filters?.Remove("sortField");
                filters?.Remove("sortDirection");
                filters?.Remove("page");
                filters?.Remove("size");

                var pageList = await _service.GetFilteredPagination(filters, sortField, sortDirection, page, size);
                var pageData = _mapper.Map<PaginatedResponse>(pageList);
                ViewData["PageData"] = pageData;
                ViewData["Filters"] = filters;
                return View(pageList.Items);
            }
            catch
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi lấy dữ liệu. Vui lòng thử lại sau.";
                return RedirectToAction("Error", "Error", new { statusCode = 500 });
            }
        }
        public virtual async Task<IActionResult> Details(TKey id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                return PartialView(entity);
            }
            catch
            {
                TempData["ErrorMessage"] = "Không thể tìm thấy dữ liệu chi tiết.";
                return RedirectToAction("Error", "Error", new { statusCode = 500 });
            }
        }
        public virtual async Task<ActionResult> Create()
        {
            await Task.Yield();
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TModel model, IFormFile? fileImage)
        {
            try
            {
                var publicIdProperty = typeof(TModel).GetProperty("PublicId");
                var imageUrlProperty = typeof(TModel).GetProperty("ImageUrl");

                if (publicIdProperty != null && imageUrlProperty != null)
                {
                    if (fileImage != null && fileImage.Length > 0)
                    {
                        var resImgUploader = await _imageUploader.UploadImageAsync(fileImage, typeof(TEntity).Name);
                        publicIdProperty.SetValue(model, resImgUploader.PublicId);
                        imageUrlProperty.SetValue(model, resImgUploader.Url);
                    }
                    else
                    {
                        publicIdProperty.SetValue(model, null);
                        imageUrlProperty.SetValue(model, "https://res-console.cloudinary.com/drk83zqgs/media_explorer_thumbnails/6d6a5b0e8c5f1954f29b609202821745/detailed");
                    }

                    // Cập nhật lại giá trị trong ModelState
                    var imageUrlModelState = ModelState["ImageUrl"];
                    if (imageUrlModelState != null)
                    {
                        imageUrlModelState.ValidationState = ModelValidationState.Valid;
                    }
                }

                if (typeof(TKey) == typeof(string))
                {
                    var id = new Guid();
                    var idProperty = typeof(TModel).GetProperty("Id");
                    idProperty?.SetValue(model, id);
                }

                var idModelState = ModelState["Id"];
                if (idModelState != null)
                {
                    idModelState.ValidationState = ModelValidationState.Valid;
                }

                if (ModelState.IsValid)
                {
                    var res = await _service.AddAsync(model);
                    TempData["SuccessMessage"] = "Thêm mới thành công: ";
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = "Dữ liệu nhập không hợp lệ.";
                return PartialView(_mapper.Map<TEntity>(model));
            }
            catch (Exception ex)
            {
                var exp = ex;
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi thêm mới dữ liệu.";
                return RedirectToAction("Error", "Error", new { statusCode = 500 });
            }
        }
        public virtual async Task<IActionResult> Edit(TKey id)
        {
            try
            {
                var entity = await _service.GetItemUpdateByIdAsync(id);
                return PartialView(entity);
            }
            catch
            {
                TempData["ErrorMessage"] = "Không thể tìm thấy dữ liệu cần chỉnh sửa.";
                return RedirectToAction("Error", "Error", new { statusCode = 500 });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(TKey id, TModel model, IFormFile? fileImage)
        {
            try
            {
                // Get TModel
                var editModel = await _service.GetByIdAsync(id);

                var publicIdProperty = typeof(TModel).GetProperty("PublicId");
                var imageUrlProperty = typeof(TModel).GetProperty("ImageUrl");
                var createdAtProperty = typeof(TModel).GetProperty("CreatedAt");

                // set CreatedAt
                var editModelCreatedAt = editModel.GetType().GetProperty("CreatedAt");
                var editModelCreatedAtObject = editModelCreatedAt?.GetValue(editModel);
                var editModelCreatedAtValue = editModelCreatedAtObject?.ToString();
                createdAtProperty?.SetValue(model, DateTime.Parse(editModelCreatedAtValue ?? new DateTime().ToString()));

                if (publicIdProperty != null && imageUrlProperty != null)
                {
                    // Get PublicId
                    var editModelPublicId = editModel.GetType().GetProperty("PublicId");
                    var editModelPublicIdObject = editModelPublicId?.GetValue(editModel);
                    var editModelPublicIdValue = editModelPublicIdObject?.ToString();

                    // Get ImageUrl
                    var editModelImageUrl = editModel.GetType().GetProperty("ImageUrl");
                    var editModelImageUrlObject = editModelImageUrl?.GetValue(editModel);
                    var editModelImageUrlValue = editModelImageUrlObject?.ToString();

                    if (fileImage != null && fileImage.Length > 0)
                    {
                        // Remove img
                        var isDeleteImg = await _imageUploader.RemoveImageAsync(editModelPublicIdValue);

                        var resImgUploader = await _imageUploader.UploadImageAsync(fileImage, typeof(TEntity).Name);
                        publicIdProperty.SetValue(model, resImgUploader.PublicId);
                        imageUrlProperty.SetValue(model, resImgUploader.Url);
                    }
                    else
                    {
                        publicIdProperty.SetValue(model, editModelPublicIdValue);
                        imageUrlProperty.SetValue(model, editModelImageUrlValue);
                    }
                    // Cập nhật lại giá trị trong ModelState
                    var imageUrlModelState = ModelState["ImageUrl"];
                    if (imageUrlModelState != null)
                    {
                        imageUrlModelState.ValidationState = ModelValidationState.Valid;
                    }
                }

                if (ModelState.IsValid)
                {
                    var res = await _service.UpdateAsync(id, model);
                    TempData["SuccessMessage"] = "Cập nhật thành công:";
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = "Dữ liệu nhập không hợp lệ.";
                return PartialView(_mapper.Map<TEntity>(model));
            }
            catch
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi cập nhật dữ liệu.";
                return RedirectToAction("Error", "Error", new { statusCode = 500 });
            }
        }
        public virtual async Task<IActionResult> Delete(TKey id)
        {
            try
            {
                var entity = await _service.GetItemUpdateByIdAsync(id);
                return PartialView(_mapper.Map<TModel>(entity));
            }
            catch
            {
                TempData["ErrorMessage"] = "Không thể tìm thấy dữ liệu để xóa.";
                return RedirectToAction("Error", "Error", new { statusCode = 500 });
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(TKey id)
        {
            try
            {
                var isdeleted = await _service.DeleteAsync(id);
                if (isdeleted)
                {
                    TempData["SuccessMessage"] = "Xóa thành công.";
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = "Không thể xóa dữ liệu.";
                return PartialView();
            }
            catch
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi xóa dữ liệu.";
                return RedirectToAction("Error", "Error", new { statusCode = 500 });
            }
        }

        public virtual async Task<IActionResult> GetFilteredPagination(
            Dictionary<string, string>? filters,
            string? sortField,
            string? sortDirection,
            int page = 1,
            int size = 10)
        {
            try
            {
                var pageList = await _service.GetFilteredPagination(filters, sortField, sortDirection, page, size);
                return PartialView(pageList.Items);
            }
            catch
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi lấy dữ liệu. Vui lòng thử lại sau.";
                return RedirectToAction("Error", "Error", new { statusCode = 500 });
            }
        }
    }
}
