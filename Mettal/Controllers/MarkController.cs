using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    public class MarkController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new MarkView
            {
                Marks = GetViewModelCollection<Mark, MarkViewModel>().ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(MarkViewModel vm)
        {
            if (ModelState.IsValid)
            {
                CreateModel<Mark, MarkViewModel>(vm);
            }
            var items = GetViewModelCollection<Mark, MarkViewModel>().ToList();
            return PartialView("_MarkList", items);
        }

        [HttpPut]
        public ActionResult Update(List<MarkViewModel> vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_MarkList", vm);
            }

            foreach (var item in vm)
            {
                UpdateModel<Mark, MarkViewModel>(item, item.Id);
            }

            var items = GetViewModelCollection<Mark, MarkViewModel>().ToList();

            return PartialView("_MarkList", items);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DeleteModel<Mark>(id);

            var items = GetViewModelCollection<Mark, MarkViewModel>().ToList();

            return PartialView("_MarkList", items);
        }
    }
}