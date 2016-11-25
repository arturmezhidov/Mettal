using System.Linq;
using System.Web.Mvc;
using Mettal.Helpers;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;
using WebGrease.Css.Ast.Selectors;

namespace Mettal.Controllers
{
    public class ProductController : BaseController
    {
        public ActionResult Positions(int id)
        {
            var category = DataContext.GetRepository<Category>().GetById(id);

            var vm = new PositionsView
            {
                Category = category.DisplayName,
                CategoryId = id,
                Positions = PositionHelper.GetPositionMembers(category.Products, category.Table).OrderBy(i => i.OrderNumber).ToList()
            };

            if (vm.Positions.Count > 0 && vm.Positions[0].Values.Count > 0)
            {
                vm.RowsCount = vm.Positions[0].Values.Count;
            }

            return View(vm);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var vm = new ProductViewModel
            {
                CategoryId = id,
                Category = DataContext.GetRepository<Category>().GetById(id),
                Marks = DataContext.GetRepository<Mark>().GetAll().ToList(),
                Countries = DataContext.GetRepository<Country>().GetAll().ToList(),
                Gosts = DataContext.GetRepository<Gost>().GetAll().ToList(),
                Targets = DataContext.GetRepository<Target>().GetAll().ToList()
            };

            if (vm.Category?.Table == null)
            {
                return Redirect("/Category");
            }
        
            return View(vm);
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel vm)
        {
            if (vm == null)
            {
                return Redirect("/Category");
            }

            var model = ToCreateModel(vm);
            DataContext.GetRepository<Product>().Create(model);
            DataContext.Save();

            return RedirectToAction("Positions", new { id = vm.CategoryId } );
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = DataContext.GetRepository<Product>().GetById(id);

            if (model == null)
            {
                return Redirect("/Category");
            }

            var vm = ToViewModel(model);

            if (vm.Category?.Table == null)
            {
                return Redirect("/Category");
            }

            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel vm)
        {
            if (vm == null)
            {
                return Redirect("/Category");
            }

            var model = DataContext.GetRepository<Product>().GetById(vm.Id);

            if (model == null)
            {
                return Redirect("/Category");
            }

            ToEditModel(model, vm);

            DataContext.GetRepository<Product>().Update(model);
            DataContext.Save();

            return RedirectToAction("Positions", new { id = vm.CategoryId });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DataContext.GetRepository<Product>().Delete(id);

            return new EmptyResult();
        }

        protected Product ToCreateModel(ProductViewModel vm)
        {
            return new Product
            {
                Id = vm.Id,
                Info1 = vm.Info1,
                Info2 = vm.Info2,
                Info3 = vm.Info3,
                Country = DataContext.GetRepository<Country>().GetById(vm.CountryId),
                Category = DataContext.GetRepository<Category>().GetById(vm.CategoryId),
                Mark = DataContext.GetRepository<Mark>().GetById(vm.MarkId),
                Target = DataContext.GetRepository<Target>().GetById(vm.TargetId),
                Gost = DataContext.GetRepository<Gost>().GetById(vm.GostId),
                Name = vm.Name,
                Price = vm.Price,
                Weight = vm.Weight,
                WeightOne = vm.WeightOne,
                WeightOneKg = vm.WeightOneKg,
                Description = vm.Description,
                Width = vm.Width,
                Height = vm.Height,
                Thickness = vm.Thickness,
                Stenka = vm.Stenka,
                Length = vm.Length,
                Sechenie = vm.Sechenie,
                Surface = vm.Surface,
                Diameter = vm.Diameter
            };
        }
        protected Product ToEditModel(Product model, ProductViewModel vm)
        {
            Table table = model.Category.Table;

            if (table.NameIsShow)
            {
                model.Name = vm.Name;
            }

            if (table.PriceIsShow)
            {
                model.Price = vm.Price;
            }

            if (table.WeightIsShow)
            {
                model.Weight = vm.Weight;
            }

            if (table.WeightOneIsShow)
            {
                model.WeightOne = vm.WeightOne;
            }

            if (table.WeightOneKgIsShow)
            {
                model.WeightOneKg = vm.WeightOneKg;
            }

            if (table.WidthIsShow)
            {
                model.Width = vm.Width;
            }

            if (table.HeightIsShow)
            {
                model.Height = vm.Height;
            }

            if (table.ThicknessIsShow)
            {
                model.Thickness = vm.Thickness;
            }

            if (table.StenkaIsShow)
            {
                model.Stenka = vm.Stenka;
            }

            if (table.LengthIsShow)
            {
                model.Length = vm.Length;
            }

            if (table.DiameterIsShow)
            {
                model.Diameter = vm.Diameter;
            }

            if (table.SechenieIsShow)
            {
                model.Sechenie = vm.Sechenie;
            }

            if (table.SurfaceIsShow)
            {
                model.Surface = vm.Surface;
            }

            if (table.DescriptionIsShow)
            {
                model.Description = vm.Description;
            }

            if (table.Info1IsShow)
            {
                model.Info1 = vm.Info1;
            }

            if (table.Info2IsShow)
            {
                model.Info2 = vm.Info2;
            }

            if (table.Info3IsShow)
            {
                model.Info3 = vm.Info3;
            }

            if (table.CountryIsShow)
            {
                model.Country = DataContext.GetRepository<Country>().GetById(vm.CountryId);
            }

            if (table.MarkIsShow)
            {
                model.Mark = DataContext.GetRepository<Mark>().GetById(vm.MarkId);
            }

            if (table.TargetIsShow)
            {
                model.Target = DataContext.GetRepository<Target>().GetById(vm.TargetId);
            }

            if (table.GostIsShow)
            {
                model.Gost = DataContext.GetRepository<Gost>().GetById(vm.GostId);
            }

            return model;
        }
        protected ProductViewModel ToViewModel(Product model)
        {
            return new ProductViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Weight = model.Weight,
                Width = model.Width,
                WeightOneKg = model.WeightOneKg,
                Stenka = model.Stenka,
                Length = model.Length,
                Sechenie = model.Sechenie,
                Height = model.Height,
                Diameter = model.Diameter,
                Thickness = model.Thickness,
                Description = model.Description,
                Surface = model.Surface,
                Price = model.Price,
                Info1 = model.Info1,
                Info2 = model.Info2,
                Info3 = model.Info3,
                WeightOne = model.WeightOne,
                Category = model.Category,
                CategoryId = model.Category.Id,
                CountryId = model.Country.Id,
                GostId = model.Gost.Id,
                MarkId = model.Mark.Id,
                TargetId = model.Target.Id,
                Marks = DataContext.GetRepository<Mark>().GetAll().ToList(),
                Countries = DataContext.GetRepository<Country>().GetAll().ToList(),
                Gosts = DataContext.GetRepository<Gost>().GetAll().ToList(),
                Targets = DataContext.GetRepository<Target>().GetAll().ToList()
            };
        }
    }
}