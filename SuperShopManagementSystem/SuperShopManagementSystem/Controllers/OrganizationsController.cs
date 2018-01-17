using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    public class OrganizationsController : Controller
    {
        OrganizationBLL organizationBll = new OrganizationBLL();
        DropDownList dropDown = new DropDownList();
        bool status = false;
        Common common = new Common();

        //Get: Create Organization
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create Organization
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization, HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please Upload an Image");
            }

            if (ImageFile != null)
            {
                bool isValidFormat = common.CheckImageFormat(ImageFile);
                if (isValidFormat == false)
                {
                    ModelState.AddModelError("Image", "Only jpg , png , jpeg are allowed");
                }
                else
                {
                    byte[] convertedImage = common.ConvertImage(ImageFile);
                    organization.Image = convertedImage;
                }
                
                
            }

            organization.IsDeleted = false;
            if (ModelState.IsValid)
            {

                status = organizationBll.Create(organization);
                if (status == true)
                {

                    ViewBag.Msg = "Organization Successfully Added";
                    ModelState.Clear();
                    return View();
                }
                if (status == false)
                {

                    ViewBag.Msg = "Organization Added Failed";
                }

            }
            return View(organization);
        }


        //Update Organization  [Get Request]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Organization Organization = organizationBll.GetById(id);

            if (Organization == null)
            {
                return RedirectToAction("Error", "Home", null);
            }

            return View(Organization);
        }



        //Update Organization Category [Post Request]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Organization organization, HttpPostedFileBase ImageFile, byte[] CurrentImage)
        {

            if (ImageFile == null)
            {

                organization.Image = CurrentImage;
            }

            if (ImageFile != null)
            {
                bool isValidFormat = common.CheckImageFormat(ImageFile);
                if (isValidFormat == false)
                {
                    organization.Image = CurrentImage;
                    ModelState.AddModelError("Image", "Only jpg , png , jpeg are allowed");
                }
                else
                {
                    organization.Image = common.ConvertImage(ImageFile);
                }
                
            }

            if (ModelState.IsValid)
            {

                status = organizationBll.Update(organization);
                if (status == true)
                {
                    return RedirectToAction("ShowAll");
                }
                if (status == false)
                {

                    ViewBag.Msg = "Organization Category Added Failed";
                }

            }
            return View(organization);
        }



        [HttpPost]
        //Delete Organization [Post Request]
        public JsonResult Delete(int id)
        {
            status = organizationBll.Delete(id);
            if (status)
            {
                return Json(1);
            }
            return Json(0);
        }



        //Show All Organization
        public ActionResult ShowAll()
        {

            List<Organization> listOfOrganization = organizationBll.GetAll();
            return View(listOfOrganization);
        }


        //Show Organization Detail
        public ActionResult Details(int? id)
        {
            Organization organization = organizationBll.GetById(id);
            return PartialView("Details_Partial", organization);
        }


        //Get All Parent Category
        public JsonResult GetParentCategories()
        {
            var listOfOrganization = organizationBll.GetParentCategories();

            return Json(listOfOrganization, JsonRequestBehavior.AllowGet);
        }


        //Generating Random Organization Code
        public JsonResult GetOrganizationCode()
        {
            string organizationCode = organizationBll.GetOrganizationCode();
            return Json(organizationCode);
        }


        //Checking Organization Name Availability
        public JsonResult CheckOrganizationName(string organizationName)
        {
            status = organizationBll.CheckOrganizationName(organizationName);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);


        }
    }
}