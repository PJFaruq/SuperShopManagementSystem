using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    public class OutletsController : Controller
    {
        OutletBLL outletBll = new OutletBLL();
        DropDownList dropDown = new DropDownList();
        bool status = false;

        //GET: Create Outlet 
        public ActionResult Create()
        {
            ViewBag.OutletCategoryId = dropDown.GetAllOrganization();
            return View();
        }


        //POST: Create Outlet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Outlet outlet)
        {

            outlet.IsDeleted = false;

            if (ModelState.IsValid)
            {

                status = outletBll.Create(outlet);
                if (status == true)
                {

                    ViewBag.Msg = "Outlet Successfully Added";
                    ModelState.Clear();
                    ViewBag.OutletCategoryId = dropDown.GetAllOrganization();
                    return View();
                }
                if (status == false)
                {

                    ViewBag.Msg = "Outlet Added Failed";
                }

            }
            ViewBag.OutletCategoryId = dropDown.GetAllOrganization();
            return View(outlet);
        }



        //GET: Update Outlet
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Outlet outlet = outletBll.GetById(id);

            if (outlet == null)
            {
                return RedirectToAction("Error", "Home", null);
            }

            ViewBag.OutletCategoryId = dropDown.GetAllOrganization();
            return View(outlet);
        }



        //POST: Update Outlet Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Outlet outlet)
        {

            if (ModelState.IsValid)
            {

                status = outletBll.Update(outlet);
                if (status == true)
                {
                    return RedirectToAction("ShowAll");
                }
                if (status == false)
                {

                    ViewBag.Msg = "Outlet Category Added Failed";
                }

            }
            ViewBag.OutletCategoryId = dropDown.GetAllOrganization();
            return View(outlet);
        }



        [HttpPost]
        //Delete Outlet [Post Request]
        public JsonResult Delete(int id)
        {
            status = outletBll.Delete(id);
            if (status)
            {
                return Json(1);
            }
            return Json(0);
        }



        //Show All Outlet
        public ActionResult ShowAll()
        {

            List<Outlet> listOfOutlet = outletBll.GetAll();
            return View(listOfOutlet);
        }


        //Generating Random Category Code
        public JsonResult GetOutletCode()
        {
            string outletCode = outletBll.GetOutletCode();
            return Json(outletCode);
        }


        //Checking Outlet Name Availability
        public JsonResult CheckOutletName(string outletName, int organizationName)
        {
            status = outletBll.CheckOutletName(outletName, organizationName);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);


        }

    }
}