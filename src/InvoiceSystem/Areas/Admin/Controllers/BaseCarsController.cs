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

namespace InvoiceSystem.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [Authorize(Roles = "Admin")]
    public class BaseCarsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICarFService _carFService;
        public BaseCarsController(ICarFService carFService,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _carFService = carFService;
        }
        public async Task<IActionResult> Index(int? id = null)
        {
            ViewBag.CarParentName = "";
            var carFs = await _carFService.GetAllByParentIdAsync(id);
            if ((carFs?.Count ?? 0) > 0)
            {
                var carF = carFs.FirstOrDefault();
                ViewBag.PageName = PublicMethods.CarFType()[(int)carF.CarFType] + (id.HasValue ? (" " + carF.Parent?.Name) : string.Empty);
                if ((carF.Children?.Count ?? 0) > 0)
                {
                    ViewBag.ChildrenPageName = PublicMethods.CarFType()[(int)carF.Children.FirstOrDefault().CarFType];
                }
                switch (carF.CarFType)
                {
                    case PublicMethods.CarFTypeEnum.Model:
                        ViewBag.CarParentName = "برند";
                        ViewBag.CarParentId = null;
                        break;

                    case PublicMethods.CarFTypeEnum.Tip:
                        ViewBag.CarParentName = carF.Parent?.Name;
                        ViewBag.CarParentId = carF.Parent.ParentId;
                        break;
                }
            }

            var carFViewModels = _mapper.Map<List<BaseCarViewModel>>(carFs);
            return View(carFs);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carF = await _carFService.FindByIdAsync(id.Value);
            if (carF == null)
            {
                return NotFound();
            }

            var carFViewModel = new BaseCarViewModel
            {
                Id = carF.Id,
                ParentId = carF.ParentId,
                Name = carF.Name,
            };
            if (carF.CarFType == PublicMethods.CarFTypeEnum.Model)
            {
                carFViewModel.BrandName = carF.Parent.Name;
            }
            else if (carF.CarFType == PublicMethods.CarFTypeEnum.Tip)
            {
                carFViewModel.BrandName = carF.Parent?.Parent?.Name;
                carFViewModel.ModelName = carF.Parent.Name;
            }

            ViewBag.PageName = PublicMethods.CarFType()[(int)carF.CarFType];
            ViewBag.CarFType = carF.CarFType;
            return View(carFViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BaseCarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _carFService.EditAsync(viewModel);
                if (result)
                {
                    return RedirectToAction(nameof(Index), new { id = viewModel.ParentId });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "یک خطا در سمت سرور رخ داده است");
                }
            }

            return View(viewModel);
        }
    }
}