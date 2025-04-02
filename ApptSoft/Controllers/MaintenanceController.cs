﻿using ApptSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApptSoft.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        public ActionResult MaintenanceIndex()
        {
            return View();
        }
        public ActionResult SaveMaintenance(MaintenanceModel model)
        {
            try
            {
                return Json(new { Message = new MaintenanceModel().SaveMaintenanceData(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult GetMaintenance(string Year = "", string month = "")
        {
            try
            {
                if (Year == "" && month == "")
                {
                    return Json(new { Message = new MaintenanceModel().GetMaintenanceData() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Message = new MaintenanceModel().GetMaintenanceDataseacr(Year, month) }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteMaintenance(int Id)
        {
            try
            {
                return Json(new { model = (new MaintenanceModel().DeleteMaintenanceData(Id)) },
                   JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult EditMaintenance(int Id)
        {
            try
            {
                return Json(new { model = (new MaintenanceModel().GetMaintenanceData(Id)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}