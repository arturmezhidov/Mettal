using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    [Authorize(Roles = "admin")]
    public class ManualController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            ManualView vm = GetView();

            return View(vm);
        }

        [HttpGet]
        public ActionResult Categories()
        {
            ManualView vm = GetView();

            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateCategory(ManualCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                ManualCategory category = new ManualCategory
                {
                    Name = vm.Name
                };
                DataContext.GetRepository<ManualCategory>().Create(category);
                DataContext.Save();
            }
            var items = GetCategoryViewModels();
            return PartialView("_ManualCategoryList", items);
        }

        [HttpPut]
        public ActionResult UpdateCategory(List<ManualCategoryViewModel> vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_ManualCategoryList", vm);
            }

            var repo = DataContext.GetRepository<ManualCategory>();

            if (repo != null)
            {
                foreach (var item in vm)
                {
                    ManualCategory category = repo.GetById(item.Id);

                    if (category != null)
                    {
                        category.Name = item.Name;
                        repo.Update(category);
                    }
                }

                DataContext.Save();
            }

            var items = GetCategoryViewModels();

            return PartialView("_ManualCategoryList", items);
        }

        [HttpDelete]
        public ActionResult DeleteCategory(int id)
        {
            DeleteModel<ManualCategory>(id);

            var items = GetCategoryViewModels();

            return PartialView("_ManualCategoryList", items);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var manual = GetViewModel<Manual, ManualViewModel>(id);

            if (manual == null)
            {
                return RedirectToAction("Index");
            }

            return View(manual);
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Categories");
            }

            var category = DataContext.GetRepository<ManualCategory>().GetById(id);

            if (category == null)
            {
                return RedirectToAction("Categories");
            }

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ManualViewModel vm, int id)
        {
            var category = DataContext.GetRepository<ManualCategory>().GetById(id);

            if (category == null)
            {
                return RedirectToAction("Categories");
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Manual manual = new Manual
            {
                Name = vm.Name,
                HtmlContent = vm.HtmlContent,
                Category = category,
                IsDeleted = false
            };

            DataContext.GetRepository<Manual>().Create(manual);
            DataContext.Save();

            return RedirectToAction("Details", new { manual.Id });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var manual = GetViewModel<Manual, ManualViewModel>(id);

            if (manual == null)
            {
                return RedirectToAction("Index");
            }

            return View(manual);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ManualViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Manual manual = DataContext.GetRepository<Manual>().GetById(vm.Id);

            if (manual == null)
            {
                return RedirectToAction("Categories");
            }

            manual.Name = vm.Name;
            manual.HtmlContent = vm.HtmlContent;

            DataContext.GetRepository<Manual>().Update(manual);
            DataContext.Save();

            return RedirectToAction("Details", new { id = vm.Id });
        }

        public ActionResult Delete(int id)
        {
            DeleteModel<Manual>(id);

            return RedirectToAction("Index");
        }

        protected ManualView GetView()
        {
            ManualView view = new ManualView
            {
                Settings = Settings,
                Categories = GetCategoryViewModels()
            };

            return view;
        }
        protected List<ManualCategoryViewModel> GetCategoryViewModels()
        {
            var result = new List<ManualCategoryViewModel>();
            var items = DataContext.GetRepository<ManualCategory>().GetAll().ToList();

            foreach (ManualCategory category in items)
            {
                var vmCategory = new ManualCategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
                foreach (Manual manual in category.Manuals.Where(i => !i.IsDeleted))
                {
                    var vmManual = new ManualViewModel
                    {
                        Id = manual.Id,
                        Name = manual.Name,
                        HtmlContent = manual.HtmlContent
                    };
                    vmCategory.Manuals.Add(vmManual);
                }
                result.Add(vmCategory);
            }

            return result;
        }
    }
}