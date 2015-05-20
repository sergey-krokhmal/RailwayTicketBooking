using RailwayTicketBooking.Models;
using System.Web.Mvc;

namespace RailwayTicketBooking.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (AccountManager.UserExist(model.Login))
            {
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationData regData)
        {
            int errorCode = AccountManager.RegisterUser()
            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }
    }
}
