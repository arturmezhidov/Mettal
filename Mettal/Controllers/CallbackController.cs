using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    public class CallbackController : Controller
    {
        [HttpPost]
        public ActionResult Call(CallbackViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CallForm", vm);
            }

            return PartialView("_CallbackResult", true);
        }

        [HttpGet]
        public ActionResult Form()
        {
            return PartialView("_CallForm", new CallbackViewModel());
        }
    }
}