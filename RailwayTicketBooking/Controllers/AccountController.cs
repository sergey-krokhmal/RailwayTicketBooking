﻿using RailwayTicketBooking.Models;
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
            try
            {
                if (ModelState.IsValid)
                {
                    if (AccountManager.RegisterUser(regData))
                    {
                        Message msg = new Message("Регистрация завершена", "Вы успешно зарегистрировали учетную запись. Теперь вы можете войти в систему, используя логин и пароль");
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
