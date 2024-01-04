using Microsoft.AspNetCore.Mvc;
using InvoiceSystem.Services.Contracts.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Components
{
    public class RenderSectionViewComponent : ViewComponent
    {
        #region Properties
        //private readonly ISectionService _sectionService;
        //private readonly ISliderService _sliderService;
        //private readonly IAdService _adService;
        private readonly IMenuService _menuService;
        #endregion

        #region ctor
        public RenderSectionViewComponent(
            //ISectionService sectionService,
            //ISliderService sliderService,
            //IAdService adService
            IMenuService menuService
            )
        {
            //_sectionService = sectionService;
            //_sliderService = sliderService;
            //_adService = adService;
            _menuService = menuService;
        }
        #endregion

        #region InvokeAsync
        public async Task<IViewComponentResult> InvokeAsync(string SectionName)
        {

            switch (SectionName)
            {
                //case "ServicesSection":
                //    var _servicesSection = await _sectionService.Get_SectionB_Async();
                //    return View("~/Views/Home/_servicesSection.cshtml", _servicesSection);

                //case "MainSlider":
                //    var _mainSlider = await _sliderService.GetAllAsync();
                //    return View("~/Views/Home/_mainSlider.cshtml", _mainSlider);

                //case "WelcomeSection":
                //    var _welcomeSection = await _sectionService.Get_SectionA_Async();
                //    return View("~/Views/Home/_welcomeSection.cshtml", _welcomeSection);
                //case "BannerSection":
                //    var _bnrSection = await _sectionService.Get_SectionE_Async();
                //    return View("~/Views/Home/_bnrSection.cshtml", _bnrSection);

                //case "StepsSection":
                //    var _stepSection = await _sectionService.Get_SectionD_Async();
                //    return View("~/Views/Home/_stepsSection.cshtml", _stepSection);

                //case "IsotopSection":
                //    var isotopAds = await _adService.Get_TakeCount_Async(15);
                //    return View("~/Views/Home/_isotopSection.cshtml", isotopAds);

                //case "SearchSection":
                //    return View("~/Views/Home/_searchSection.cshtml");



                //case "ProgressSection":
                //    var _progressSection = await _sectionService.Get_SectionC_Async();
                //    return View("~/Views/Home/_progressSection.cshtml", _progressSection);

                //case "CarouselSection":
                //    var ads = await _adService.Get_TakeCount_Async(10);
                //    return View("~/Views/Home/_carouselSection.cshtml", ads);

                case "AdminHeadLayout":
                    return View("~/Views/Shared/Admin/_adminHeadLayout.cshtml");
                case "AdminNavbar":
                    var menus = _menuService.GetMenus(MenuTypeEnum.adminpanel).Result;
                    return View("~/Views/Shared/Admin/_adminNavbar.cshtml", menus);


                default:
                    return View($"~/Views/Shared/Partials/{SectionName}.cshtml");

            }
        }
        #endregion
    }
}
