using Mettal.Models.Entities;
using Mettal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mettal.Controllers
{
    public class SliderController : BaseController
    {
        public ActionResult Index()
        {
            var slides = GetViewModelCollection<Slide, SlideViewModel>();

            return View(slides);
        }
    }
}