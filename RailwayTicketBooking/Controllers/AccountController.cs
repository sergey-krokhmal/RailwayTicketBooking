using RailwayTicketBooking.Models;
using System;
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

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["user_id"] == null)
            {
                return PartialView();
            }
            else
            {
                AccountManager am = new AccountManager();
                LoggedUser lu = am.GetLoggedUserById((int)Session["user_id"]);
                return PartialView("_UserCard", lu);
            }
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            AccountManager am = new AccountManager();
            if (am.UserExist(model.Login))
            {
                Session["user_id"] = am.GetIdByLogin(model.Login);
                return RedirectToAction("Index", "Message", new { title = "Вход выполнен", body = "Вы успешно вошли в систему" });
            }
            else
            {
                return RedirectToAction("Index", "Message", new { title = "Ошибка входа в систему", body = "Вы ввели неправильный логин или еще не зарегистрировались" });
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
            try
            {
                if (ModelState.IsValid)
                {
                    AccountManager am = new AccountManager();
                    if (am.RegisterUser(regData))
                    {
                        return RedirectToAction("Index", "Message", new { title = "Регистрация завершена", body = "Вы успешно зарегистрировали учетную запись" });
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(regData);
        }
    }
}
