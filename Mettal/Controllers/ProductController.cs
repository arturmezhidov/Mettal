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
            CategoryViewModel category = GetViewModel<Category, CategoryViewModel>(id);

            if (category == null)
            {
                Redirect("/Category");
            }

            return View(category);
        }
    }
}