using AutoMapper;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class SocialMediaLinksController : Controller
    {
        private readonly ISocialMediaLinkService _SocialMediaLinkService;
        private readonly IMapper _mapper;
        public SocialMediaLinksController(ISocialMediaLinkService SocialMediaLinkService, IMapper mapper)
        {
            _SocialMediaLinkService = SocialMediaLinkService;
            _mapper = mapper;
        }

        // GET: SocialMediaLinkController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _SocialMediaLinkService.GetSocialMediaLinksAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: SocialMediaLinkController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _SocialMediaLinkService.GetSocialMediaLinkByIdAsync(id));
        }

        // GET: SocialMediaLinkController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: SocialMediaLinkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SocialMediaLink SocialMediaLink)
        {
            try
            {
                if (SocialMediaLink.ImageUrl == null)
                {
                    SocialMediaLink.ImageUrl = "https://voduongngochoa.com/uploads/noimg.jpg";
                }
                var res = await _SocialMediaLinkService.AddSocialMediaLinkAsync(SocialMediaLink);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SocialMediaLinkController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView(await _SocialMediaLinkService.GetSocialMediaLinkByIdAsync(id));
        }

        // POST: SocialMediaLinkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SocialMediaLink SocialMediaLink)
        {
            try
            {
                SocialMediaLink.LinkId = id;
                var res = await _SocialMediaLinkService.UpdateSocialMediaLinkAsync(id, SocialMediaLink);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SocialMediaLinkController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView(await _SocialMediaLinkService.GetSocialMediaLinkByIdAsync(id));
        }

        // POST: SocialMediaLinkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var SocialMediaLinkDelete = await _SocialMediaLinkService.DeleteSocialMediaLinkAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
