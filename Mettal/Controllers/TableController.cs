using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    [Authorize(Roles = "admin")]
    public class TableController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new TableView
            {
                Tables = GetViewModelCollection<Table, TableViewModel>().ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Update(int? id = null)
        {
            if (id == null)
            {
                return View("Update", GetNewTable());
            }

            var vm = GetViewModel<Table, TableViewModel>(id);

            return View("Update", vm);
        }

        [HttpPost]
        public ActionResult Update(TableViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", vm);
            }

            if (vm.Id > 0)
            {
                UpdateModel<Table, TableViewModel>(vm, vm.Id);
            }
            else
            {
                CreateModel<Table, TableViewModel>(vm);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DeleteModel<Table>(id);

            return new EmptyResult();
        }

        protected TableViewModel GetNewTable()
        {
            var vm = new TableViewModel();
            var properties = vm
                .GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(DisplayNameAttribute)) != null);

            foreach (PropertyInfo property in properties)
            {
                var attr = property.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;

                if (attr != null)
                {
                    property.SetValue(vm, attr.DisplayName);
                }
            }

            return vm;
        }
    }
}