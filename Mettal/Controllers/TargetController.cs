using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    public class TargetController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new TargetView
            {
                Targets = GetViewModelCollection<Target, TargetViewModel>().ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(TargetViewModel vm)
        {
            if (ModelState.IsValid)
            {
                CreateModel<Target, TargetViewModel>(vm);
            }
            var items = GetViewModelCollection<Target, TargetViewModel>().ToList();
            return PartialView("_TargetList", items);
        }

        [HttpPut]
        public ActionResult Update(List<TargetViewModel> vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_TargetList", vm);
            }

            foreach (var item in vm)
            {
                UpdateModel<Target, TargetViewModel>(item, item.Id);
            }

            var items = GetViewModelCollection<Target, TargetViewModel>().ToList();

            return PartialView("_TargetList", items);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DeleteModel<Target>(id);

            var items = GetViewModelCollection<Target, TargetViewModel>().ToList();

            return PartialView("_TargetList", items);
        }
    }
}