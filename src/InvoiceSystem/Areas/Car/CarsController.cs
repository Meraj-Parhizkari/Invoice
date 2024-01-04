using InvoiceSystem.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvoiceSystem.Areas.Identity;
using InvoiceSystem.Common.Public;
using InvoiceSystem.Services.Contracts.Cars;
using InvoiceSystem.ViewModels.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InvoiceSystem.ViewModels.Public;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using static InvoiceSystem.Common.Public.PublicMethods;
using System.IO;

namespace InvoiceSystem.Areas.Carmin.Controllers
{
    [Area(AreaConstants.CarArea)]
    public class CarsController : Controller
    {
        #region Properties
        public ResponseJsonViewModel responseJsonViewModel { get; set; }

        private readonly ICarService _adService;
        private readonly ICarColorService _carColorService;
        private readonly ICarBodyStatusService _carBodyStatusService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Ctor
        public CarsController(ICarService adService,
            ICarColorService carColorService,
            ICarBodyStatusService carBodyStatusService,
            IHttpContextAccessor contextAccessor,
            IHostingEnvironment hostingEnvironment)
        {
            responseJsonViewModel = new ResponseJsonViewModel();
            _adService = adService;
            _carColorService = carColorService;
            _carBodyStatusService = carBodyStatusService;
            _contextAccessor = contextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region Create (Car Sale & Buy)
        public async Task<IActionResult> Create()
        {
            ViewBag.BodyCarColors = new SelectList((await _carColorService.GetAllByColorTypeAsync(ColorTypeEnum.BodyColor))
                .Select(x => new
                {
                    Value = x.Id,
                    Text = x.Name,
                }).ToList(), "Value", "Text");

            ViewBag.InsideCarColors = new SelectList((await _carColorService.GetAllByColorTypeAsync(ColorTypeEnum.InsideColor))
                .Select(x => new
                {
                    Value = x.Id,
                    Text = x.Name,
                }).ToList(), "Value", "Text");

            ViewBag.CarBodyStatuses = new SelectList((await _carBodyStatusService.GetAllAsync())
                .Select(x => new
                {
                    Value = x.Id,
                    Text = x.Name,
                }).ToList(), "Value", "Text");

            return View();
        }

        public async Task<IActionResult> CarBuy()
        {
            ViewBag.BodyCarColors = new SelectList((await _carColorService.GetAllByColorTypeAsync(ColorTypeEnum.BodyColor))
                .Select(x => new
                {
                    Value = x.Id,
                    Text = x.Name,
                }).ToList(), "Value", "Text");

            ViewBag.InsideCarColors = new SelectList((await _carColorService.GetAllByColorTypeAsync(ColorTypeEnum.InsideColor))
                .Select(x => new
                {
                    Value = x.Id,
                    Text = x.Name,
                }).ToList(), "Value", "Text");

            ViewBag.CarBodyStatuses = new SelectList((await _carBodyStatusService.GetAllAsync())
                .Select(x => new
                {
                    Value = x.Id,
                    Text = x.Name,
                }).ToList(), "Value", "Text");

            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(CarViewModel viewModel)
        {
            responseJsonViewModel.Status = System.Net.HttpStatusCode.InternalServerError;
            if (ModelState.IsValid)
            {
                if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    viewModel.CarStatus = CarStatusEnum.New;
                    await _adService.CreateAsync(viewModel);
                    responseJsonViewModel.Status = System.Net.HttpStatusCode.OK;
                    responseJsonViewModel.Msg = "ثبت آگهی با موفقیت انجام شد";
                    // responseJsonViewModel.Url = Url.Action(
                    //      nameof(InvoiceSystem.Controllers.ProfileController.MyCars),
                    //      nameof(InvoiceSystem.Controllers.ProfileController).ToControllerName(),
                    //      new { area = "" });
                }
                else
                {
                    responseJsonViewModel.Status = System.Net.HttpStatusCode.Unauthorized;
                    //responseJsonViewModel.Msg = "لطفا مجددا تلاش نمایید.";
                }
            }
            else
            {
                responseJsonViewModel.Msg = ModelState.AddModelErrors();

            }

            return Json(responseJsonViewModel);
        }
        #endregion

        #region CheckUserAuthentiacate
        public JsonResult CheckUserAuthentiacated()
        {
            responseJsonViewModel.Status = System.Net.HttpStatusCode.OK;
            responseJsonViewModel.data = _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
            return Json(responseJsonViewModel);
        }
        #endregion

        #region Upload Files
        [HttpPost]
        public async Task<JsonResult> UploadFile()
        {
            responseJsonViewModel.Status = System.Net.HttpStatusCode.InternalServerError;
            if ((Request.Form.Files?.Count ?? 0) > 0 && Request.Form.Files[0].Length > 0)
            {
                var file = Request.Form.Files[0];
                var filename = Guid.NewGuid().ToString().Replace("-", string.Empty) + Path.GetExtension(file.FileName);
                var path = Path.Combine(_hostingEnvironment.WebRootPath,
                                        PublicMethods.Paths.CarImages,
                                        filename);
                try
                {

                    using (var stream = System.IO.File.Create(path))
                    {
                        await file.CopyToAsync(stream);
                        responseJsonViewModel.Status = System.Net.HttpStatusCode.OK;
                        responseJsonViewModel.data = filename;
                    }
                }
                catch (Exception)
                {

                }
            }

            return Json(responseJsonViewModel);
        }
        #endregion

        #region RemoveUploadedFile
        public JsonResult RemoveUploadedFile(string filename)
        {
            responseJsonViewModel.Status = System.Net.HttpStatusCode.InternalServerError;

            var path = Path.Combine(_hostingEnvironment.WebRootPath,
                                    PublicMethods.Paths.CarImages,
                                    filename);

            if (System.IO.File.Exists(path))
            {
                try
                {
                    System.IO.File.Delete(path);
                    responseJsonViewModel.Status = System.Net.HttpStatusCode.OK;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return Json(responseJsonViewModel);
        }
        #endregion
    }
}