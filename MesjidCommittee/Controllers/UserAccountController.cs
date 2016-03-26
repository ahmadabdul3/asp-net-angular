using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MesjidCommittee.Models;
using MesjidCommittee.ViewModels;
using MesjidCommittee.DAL;
using MesjidCommittee.Helpers;
using MesjidCommittee.Helpers.ServerResponse;
using MesjidCommittee.Repositories;


namespace MesjidCommittee.Controllers
{
    [AllowAnonymous]
    public class UserAccountController : Controller
    {
        private UserAccountRepo userAccountRepo = new UserAccountRepo();
        public ActionResult Index(string returnUrl)
        {
            var model = new UserAccount
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            if(!ModelState.IsValid)
            {
                return Json(new ServerResponse<string, string, string>(ErrorMessages.ErrorString, ErrorMessages.ErrMsg_RequiredFieldsWereEmpty, ""));
            }
            ServerResponse<string, string, string> response = userAccountRepo.validateLogin(user, Request);
            return Json(response);
        }
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            return Json(userAccountRepo.validateRegister(user, Request));
        }
    }
}



