﻿using System;
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
    [Authorize]
    public class MembersController : Controller
    {
        private MembersRepo membersRepo = new MembersRepo();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult getMembersList()
        {
            return Json(membersRepo.getMembersList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddMember(CommunityMember cMemb)
        {
            if (ModelState.IsValid)
            {
                return Json(membersRepo.AddMember(cMemb));
            }
            return Json(ErrorMessages.getErrorFieldsEmptyServerResponse());
        }

        public ActionResult GetMember(int id)
        {
            return Json(membersRepo.GetMember(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateMember(CommunityMember model)
        {
            if (ModelState.IsValid)
            {
                return Json(membersRepo.UpdateMember(model));
            }
            return Json(ErrorMessages.getErrorFieldsEmptyServerResponse());
        }

        public ActionResult AddChild(Child child)
        {
            if (ModelState.IsValid)
            {
                return Json(membersRepo.AddChild(child), JsonRequestBehavior.AllowGet);
            }
            return Json(ErrorMessages.getErrorFieldsEmptyServerResponse(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddActivity(int Id, string ActivityName)
        {
            return Json(membersRepo.AddActivity(Id, ActivityName));
        }
        [HttpPost]
        public ActionResult DeleteActivity(int id)
        {
            return Json(membersRepo.DeleteActivity(id));
        }

        public ActionResult GetCommunityActivitiesList()
        {
            return Json(membersRepo.GetCommunityActivitiesList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteMember(int id)
        {
            try
            {
                return Json(membersRepo.DeleteMember(id));
            }
            catch (Exception e)
            {
                return Json(ErrorMessages.getErrorGenericServerResponse());
            }
        }

        [HttpPost]
        public ActionResult DeleteChild(int id)
        {
            try
            {
                return Json(membersRepo.DeleteChild(id));
            }
            catch (Exception e)
            {
                return Json(ErrorMessages.getErrorGenericServerResponse());
            }
        }

        [HttpPost]
        public ActionResult loadCsvData()
        {
            try
            {
                new CsvReader().loadCsvDataIntoDb();
                return Json(new ServerResponse<string, string, string>(ErrorMessages.SuccessString, "success", ""));
            }
            catch (Exception e)
            {
                return Json(new ServerResponse<string, string, string>(ErrorMessages.ErrMsg_Generic, e.StackTrace, ""));
            }
            
        }
    }
}