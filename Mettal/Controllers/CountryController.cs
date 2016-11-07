using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    [Authorize(Roles = "admin")]
    public class CountryController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new CountryView
            {
                Countries = GetViewModelCollection<Country, CountryViewModel>().ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(CountryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                CreateModel<Country, CountryViewModel>(vm);
            }
            var items = GetViewModelCollection<Country, CountryViewModel>().ToList();
            return PartialView("_CountryList", items);
        }

        [HttpPut]
        public ActionResult Update(List<CountryViewModel> vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CountryList", vm);
            }

            foreach (var item in vm)
            {
                UpdateModel<Country, CountryViewModel>(item, item.Id);
            }

            var items = GetViewModelCollection<Country, CountryViewModel>().ToList();

            return PartialView("_CountryList", items);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DeleteModel<Country>(id);

            var items = GetViewModelCollection<Country, CountryViewModel>().ToList();

            return PartialView("_CountryList", items);
        }
    }
}