using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Mettal.Models.Business;
using Mettal.Models.DataAccess;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;
using Mettal.Util;

namespace Mettal.Controllers
{
    public class BaseController : Controller
    {
        private UnitOfWork dataContext;
        private bool disposed = false;
        protected UnitOfWork DataContext{ get { return dataContext ?? (dataContext = new UnitOfWork()); }}

        protected AppSettings Settings
        {
            get
            {
                return new AppSettings
                {
                    Phone1 = "+375 (29) 153 67 12",
                    Phone2 = "+375 (29) 153 67 12",
                    Phone3 = "+375 (29) 153 67 12",
                    Email1 = "test-mail@gmail.com",
                    Email2 = "test-mail@gmail.com",
                    Email3 = "test-mail@gmail.com",
                    AddressOffice = "ул. Ольшевского 19, Минск",
                    OfficeMapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3952.154278938668!2d27.497291104207036!3d53.914597958269944!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x46dbc543f51558f1%3A0x776838c60ee3d4b9!2z0YPQuy4g0J7Qu9GM0YjQtdCy0YHQutC-0LPQviAxOSwg0JzQuNC90YHQug!5e0!3m2!1sru!2sby!4v1476307788400",
                    AddressSklad = "ул. Карла Либкнехта 80/3, Минск",
                    SkladMapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2350.951347759347!2d27.52291381551474!3d53.89706868009815!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x46dbcffc4bcbc033%3A0xc0c0d41e3b4a1731!2z0YPQuy4g0JrQsNGA0LvQsCDQm9C40LHQutC90LXRhdGC0LAgODAvMywg0JzQuNC90YHQug!5e0!3m2!1sru!2sby!4v1476308562589",
                    Recvisits = @"Республика Беларусь
пр-т. Партизанский, д.6д, комн.109, 220033, г.Минск
УНП 191685915
р/с 3012163741017 в Дополнительном офисе №701 на Чкалова
ОАО «БПС-Сбербанк» г. Минск.  г.Минск, ул. Чкалова, 18/1, БИК 153001369",
                    Worktime1 = "Понидельник - Пятница",
                    Worktime2 = "8:00 - 17:00",
                    ManualAbout = "Статьи о нержавейке, которые находятся в текущем справочнике, освещают различные вопросы металлургической темы. В первом разделе представлена информация по обработке нержавеющей стали различными способами и при помощи специального оборудования. Таким образом, нержавеющий металл приобретает те нужные параметры, которые требуются от соответствующей продукции. Второй раздел дает определение нержавейки, описывает ее свойства и области применения. Здесь формируется понимание истории нержавейки и ее качеств, которые позволили нержавеющей стали занять такое важное место в различных сферах промышленности и строительства. В третьем разделе справочника перечислены основные типы металлопроката. Это данные про нержавеющие трубы и стальной лист, круг и квадрат, уголок и шестигранник, а также устройства трубопроводной арматуры. Последний раздел затрагивает насущные вопросы современного производства и строительства.",
                    ManualSubheader = "Для того, чтобы получить необходимую информацию, нужно выбрать подходящий раздел нашего сборника."
                };
            }
        }

        public BaseController()
        {
            ViewBag.Settings = Settings;
        }

        protected TViewModel GetViewModel<TModel, TViewModel>(object modelId)
            where TModel : BaseEntity
            where TViewModel : class, new()
        {
            var repo = DataContext.GetRepository<TModel>();

            if (repo == null)
            {
                return null;
            }

            var item = repo.GetById(modelId);

            if (item == null)
            {
                return null;
            }

            TViewModel vm = Mapper.Map(item, new TViewModel());

            return vm;
        }
        protected IEnumerable<TViewModel> GetViewModelCollection<TModel, TViewModel>()
            where TModel : BaseEntity
            where TViewModel : class, new()
        {
            var repo = DataContext.GetRepository<TModel>();

            if (repo == null)
            {
                return null;
            }

            var items = repo.GetAll().Select(map<TModel, TViewModel>);

            return items;
        }

        protected TModel CreateModel<TModel, TViewModel>(TViewModel vm)
            where TModel : BaseEntity, new()
            where TViewModel : class
        {
            if (vm == null)
            {
                return null;
            }

            TModel model = Mapper.Map(vm, new TModel());

            var repo = DataContext.GetRepository<TModel>();

            if (repo == null)
            {
                return null;
            }

            repo.Create(model);
            DataContext.Save();

            return model;
        }

        protected TModel UpdateModel<TModel, TViewModel>(TViewModel vm, object modelId)
            where TModel : BaseEntity, new()
            where TViewModel : class
        {
            if (vm == null || modelId == null)
            {
                return null;
            }

            var repo = DataContext.GetRepository<TModel>();

            if (repo == null)
            {
                return null;
            }

            var model = repo.GetById(modelId);

            if (model == null)
            {
                return null;
            }

            Mapper.Map(vm, model, new [] { "Id" });

            repo.Update(model);
            DataContext.Save();

            return model;
        }

        protected TModel DeleteModel<TModel>(object id) where TModel : BaseEntity
        {
            if (id == null)
            {
                return null;
            }

            var repo = DataContext.GetRepository<TModel>();

            if (repo == null)
            {
                return null;
            }

            var model = repo.Delete(id);

            DataContext.Save();

            return model;
        }

        private TViewModel map<TModel, TViewModel>(TModel model)
            where TModel : class
            where TViewModel : class, new()
        {
            TViewModel vm = Mapper.Map(model, new TViewModel());
            return vm;
        }

        protected string SaveFile(HttpPostedFileBase file)
        {
            string fileName = String.Format("{0}{1}", Guid.NewGuid(), Path.GetExtension(file.FileName));
            string filePath = String.Format("{0}{1}", AppConfig.CategoryImagesPath, fileName);

            file.SaveAs(Server.MapPath(filePath));

            return fileName;
        }

        protected string GetFileLink(string imagesPath, string imageName)
        {
            string link = String.IsNullOrEmpty(imageName)
                ? ""
                : VirtualPathUtility.ToAbsolute(String.Format("{0}{1}", imagesPath, imageName));
            return link;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && !disposed)
            {
                DataContext.Dispose();
                disposed = true;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ViewBag.IsAdmin = (User != null) && User.IsInRole("admin");
        }
    }
}