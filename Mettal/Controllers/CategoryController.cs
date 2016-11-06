using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    public class CategoryController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new CategoryView
            {
                Categories = GetViewModelCollection<Category, CategoryViewModel>().ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Update(int? id = null)
        {
            var vm = (id == null)
                ? new CategoryViewModel()
                : GetViewModel<Category, CategoryViewModel>(id);

            vm.Items = DataContext
                .GetRepository<ProductSchema>()
                .GetAll()
                .Where(i => !i.IsDeleted)
                .Select(i => new SelectListItem
                {
                    Text = i.TableName,
                    Value = i.Id.ToString(),
                    Selected = (i.Id == vm.ProductSchemaId)
                })
                .ToList();

            return View("Update", vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(CategoryViewModel vm)
        {
            if (vm == null)
            {
                return View("Update", new CategoryViewModel());
            }

            vm.Items = DataContext
                .GetRepository<ProductSchema>()
                .GetAll()
                .Where(i => !i.IsDeleted)
                .Select(i => new SelectListItem
                {
                    Text = i.TableName,
                    Value = i.Id.ToString(),
                    Selected = (i.Id == vm.ProductSchemaId)
                })
                .ToList();

            if (!ModelState.IsValid)
            {
                return View("Update", vm);
            }

            if (vm.Id > 0)
            {
                if (String.IsNullOrEmpty(vm.ImagePath) && vm.Image == null)
                {
                    ModelState.AddModelError("Image", new Exception("Выберите картинку"));
                    return View("Update", vm);
                }

                if (vm.Image != null)
                {
                    vm.ImagePath = SaveFile(vm.Image, AppConfig.CategoryImagesPath);
                }

                UpdateModel<Category, CategoryViewModel>(vm, vm.Id);
            }
            else
            {
                if (vm.Image == null)
                {
                    ModelState.AddModelError("Image", new Exception("Выберите картинку"));
                    return View("Update", vm);
                }

                vm.ImagePath = SaveFile(vm.Image, AppConfig.CategoryImagesPath);

                CreateModel<Category, CategoryViewModel>(vm);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DeleteModel<Category>(id);

            var items = GetViewModelCollection<Category, CategoryViewModel>().ToList();

            return PartialView("_CategoryList", items);
        }

        public ActionResult Products(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var vm = GetViewModel<Category, CategoryViewModel>(id);

            if (vm == null)
            {
                return RedirectToAction("Index");
            }

            return View(vm);
        }
    }
}