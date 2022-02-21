using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BShopTest;
namespace DressWeb.Controllers
{
    public class DressController : Controller
    {
        // GET: Dress
        public ActionResult AddDress()
        {
            var com = new DatabaseConnection();
            return View(new Dresses());
        }
        [HttpPost]
        public ActionResult AddDress(Dresses dresses)
        {
            var com = new DatabaseConnection();
            try
            {
                com.AddDress(dresses);
                //throw new Exception("Testing Error!!!");
                //  return RedirectToAction("Index");
                return View(new Dresses());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new Dresses());
            }

        }
        public ActionResult GetDress()
        {
            var con = new DatabaseConnection();
            var drs = con.GetDresses();
            return View(drs);
        }
        public ActionResult UpdateDress(string id)
        {
            int DressId = Convert.ToInt32(id);
            var com = new DatabaseConnection();
            try
            {
                
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateDress(Dresses dresses)
        {
            
            var con = new DatabaseConnection();
            try
            {
                con.UpdateDress(dresses);
                
                return View(dresses);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult DeleteDress(string id)
        {
            var con = new DatabaseConnection();
            int DressId = Convert.ToInt32(id);
            try
            {
                con.DeleteDress(DressId);
                return View(DressId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}