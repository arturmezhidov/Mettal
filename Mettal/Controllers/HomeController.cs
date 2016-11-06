using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            HomeView vm = new HomeView
            {
                Settings = Settings,
                Categories = GetViewModelCollection<Category, CategoryViewModel>().Select(ToViewCategory),
                Slides = GetViewModelCollection<Slide, SlideViewModel>().Where(i => !i.IsHidden).Select(ToViewSlide)
            };

            return View(vm);
        }

        public ActionResult Categories()
        {
            HomeView vm = new HomeView
            {
                Settings = Settings,
                Categories = GetViewModelCollection<Category, CategoryViewModel>().Select(ToViewCategory)
            };

            return View(vm);
        }

 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        private CategoryViewModel ToViewCategory(CategoryViewModel vm)
        {
            vm.ImageViewLink = GetFileLink(AppConfig.CategoryImagesPath, vm.ImagePath);
            return vm;
        }
        private SlideViewModel ToViewSlide(SlideViewModel vm)
        {
            vm.ImageUrl = GetFileLink(AppConfig.SlideImagesPath, vm.ImageUrl);
            return vm;
        }
    }
}