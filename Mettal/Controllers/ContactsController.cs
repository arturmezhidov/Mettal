using System.Web.Mvc;

namespace Mettal.Controllers
{
    public class ContactsController : BaseController
    {
        public ActionResult Index()
        {
            return View(Settings);
        }

        public ActionResult Form()
        {
            return PartialView("_FeedbackForm");
        }

        public ActionResult Submit()
        {
            return PartialView("_FeedbackResult");
        }
    }
}