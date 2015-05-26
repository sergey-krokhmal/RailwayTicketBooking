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
            if (Session["user"] == null)
            {
                return PartialView();
            }
            else
            {

                LoggedUser lu = (LoggedUser)Session["user"];
                return PartialView("_UserCard", lu);
            }
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginData)
        {
            AccountManager am = new AccountManager();
            string msgTitle;
            string msgBody;
            if (am.UserExist(loginData.Login))
            {
                LoggedUser user = am.GetLoggedUser(loginData);
                if (user == null)
                {
                    msgTitle = "Ошибка входа в систему";
                    msgBody = "Вы ввели неправильный логин или пароль";
                }
                else
                {
                    Session["user"] = user;
                    msgTitle = "Вход выполнен";
                    msgBody = "Вы успешно вошли в систему";
                }
            }
            else
            {
                msgTitle = "Ошибка входа в систему";
                msgBody = "Вы ввели неправильный логин или не зарегистрированы";
            }
            return RedirectToAction("Index", "Message", new { title = msgTitle, body = msgBody });
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
