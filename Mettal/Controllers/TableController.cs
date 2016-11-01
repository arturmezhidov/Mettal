using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    public class TableController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new ProductSchemaView
            {
                Schemas = GetViewModelCollection<ProductSchema, ProductSchemaViewModel>().ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Update(int? id = null)
        {
            if (id == null)
            {
                return View("Update", GetNewSchema());
            }

            var vm = GetViewModel<ProductSchema, ProductSchemaViewModel>(id);

            return View("Update", vm);
        }

        [HttpPost]
        public ActionResult Update(ProductSchemaViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", vm);
            }

            if (vm.Id > 0)
            {
                UpdateModel<ProductSchema, ProductSchemaViewModel>(vm, vm.Id);
            }
            else
            {
                CreateModel<ProductSchema, ProductSchemaViewModel>(vm);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DeleteModel<ProductSchema>(id);

            var items = GetViewModelCollection<ProductSchema, ProductSchemaViewModel>().ToList();

            return PartialView("_ProductSchemaList", items);
        }

        protected ProductSchemaViewModel GetNewSchema()
        {
            var vm = new ProductSchemaViewModel();
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