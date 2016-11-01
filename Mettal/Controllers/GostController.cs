using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    public class GostController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new GostView
            {
                Gosts = GetViewModelCollection<Gost, GostViewModel>().ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(GostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                CreateModel<Gost, GostViewModel>(vm);
            }
            var items = GetViewModelCollection<Gost, GostViewModel>().ToList();
            return PartialView("_GostList", items);
        }

        [HttpPut]
        public ActionResult Update(List<GostViewModel> vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_GostList", vm);
            }

            foreach (var item in vm)
            {
                UpdateModel<Gost, GostViewModel>(item, item.Id);
            }

            var items = GetViewModelCollection<Gost, GostViewModel>().ToList();

            return PartialView("_GostList", items);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DeleteModel<Gost>(id);

            var items = GetViewModelCollection<Gost, GostViewModel>().ToList();

            return PartialView("_GostList", items);
        }
    }
}