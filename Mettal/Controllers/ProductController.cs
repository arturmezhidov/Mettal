using System.Web.Mvc;
using Mettal.Models.Entities;
using Mettal.Models.ViewModels;

namespace Mettal.Controllers
{
    public class ProductController : BaseController
    {
        [HttpGet]
        public ActionResult Positions(int id)
        {
            Category category = DataContext.GetRepository<Category>().GetById(id);

            if (category == null)
            {
                Redirect("/Category");
            }



            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            if (!UpdateCategory(id))
            {
                Redirect("/Category");
            }
        
            return View();
        }




        protected virtual bool UpdateCategory(int id)
        {
            Category category = DataContext.GetRepository<Category>().GetById(id);

            if (category == null || category.Table == null)
            {
                return false;
            }

            TempData.Add("CategoryId", category.Id);
            TempData.Add("CategoryName", category.DisplayName);
            TempData.Add("CategoryName", category.Table);

            return true;
        }
    }
}