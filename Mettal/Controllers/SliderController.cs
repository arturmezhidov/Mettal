using Mettal.Models.Entities;
using Mettal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mettal.Controllers
{
    public class SliderController : BaseController
    {
        public ActionResult Index()
        {
            var slides = GetSlideViewModels();
            return View(slides);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SlideViewModel());
        }
        [HttpPost]
        public ActionResult Create(SlideViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            vm.ImageUrl = SaveFile(vm.Image, AppConfig.SlideImagesPath);
            vm.OrderNumber = DataContext.GetRepository<Slide>().GetAll().Count();

            CreateModel<Slide, SlideViewModel>(vm);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vm = GetViewModel<Slide, SlideViewModel>(id);

            if(vm == null)
            {
                return RedirectToAction("Index");
            }

            ToView(vm);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(SlideViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var slide = DataContext.GetRepository<Slide>().GetById(vm.Id);

            if(slide != null)
            {
                slide.Title = vm.Title;

                if(vm.Image != null)
                {
                    slide.ImageUrl = SaveFile(vm.Image, AppConfig.SlideImagesPath);
                }

                DataContext.GetRepository<Slide>().Update(slide);
                DataContext.Save();
            }

            return RedirectToAction("Index");
        }

        [HttpPut]
        public ActionResult Hide(int id)
        {
            var vm = GetViewModel<Slide, SlideViewModel>(id);
            
            if(vm != null)
            {
                vm.IsHidden = !vm.IsHidden;
                UpdateModel<Slide, SlideViewModel>(vm, id);

                ToView(vm);

                return PartialView("_SlideRow", vm);
            }            

            return new EmptyResult();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            DeleteModel<Slide>(id);

            var repo = DataContext.GetRepository<Slide>();

            var slides = repo.GetAll().OrderBy(i => i.OrderNumber).ToList();

            for(int i = 0; i < slides.Count; i++)
            {
                var slide = slides[i];
                slide.OrderNumber = i;
                repo.Update(slide);
            }

            DataContext.Save();

            return new EmptyResult();
        }

        [HttpPut]
        public ActionResult Up(int id)
        {
            var slides = DataContext.GetRepository<Slide>().GetAll().OrderBy(s => s.OrderNumber).ToList();

            var current = slides.FirstOrDefault(i => i.Id == id);

            if(current != null && current.OrderNumber != 0)
            {
                var last = slides[current.OrderNumber - 1];
                last.OrderNumber = current.OrderNumber;
                current.OrderNumber = current.OrderNumber - 1;

                DataContext.GetRepository<Slide>().Update(last);
                DataContext.GetRepository<Slide>().Update(current);
                DataContext.Save();
            }

            var result = GetSlideViewModels();
            return PartialView("_SlideList", result);
        }

        [HttpPut]
        public ActionResult Down(int id)
        {
            var slides = DataContext.GetRepository<Slide>().GetAll().OrderBy(s => s.OrderNumber).ToList();

            var current = slides.FirstOrDefault(i => i.Id == id);

            if (current != null && current.OrderNumber < slides.Count - 1)
            {
                var next = slides[current.OrderNumber + 1];
                next.OrderNumber = current.OrderNumber;
                current.OrderNumber = current.OrderNumber + 1;

                DataContext.GetRepository<Slide>().Update(next);
                DataContext.GetRepository<Slide>().Update(current);
                DataContext.Save();
            }

            var result = GetSlideViewModels();
            return PartialView("_SlideList", result);
        }

        protected SlideViewModel ToView(SlideViewModel vm)
        {
            if(vm == null)
            {
                return null;
            }

            vm.ImageUrl = GetFileLink(AppConfig.SlideImagesPath, vm.ImageUrl);

            return vm;
        }
        protected List<SlideViewModel> GetSlideViewModels()
        {
            var result = GetViewModelCollection<Slide, SlideViewModel>().OrderBy(s => s.OrderNumber).Select(ToView).ToList();
            if (result.Count > 0)
            {
                var first = result.FirstOrDefault();
                var last = result.LastOrDefault();
                if (first != null)
                {
                    first.IsFirst = true;
                }
                if (last != null)
                {
                    last.IsLast = true;
                }
            }
            return result;
        }
    }
}