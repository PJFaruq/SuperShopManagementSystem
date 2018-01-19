using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    public class PartiesController : Controller
    {
        PartyBLL partyBll = new PartyBLL();
        Common common = new Common();
        DropDownList dropDown = new DropDownList();
        bool status = false;

        //GET: Create Party 
        public ActionResult Create()
        {
            return View();
        }


        //POST: Create Party
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Party party, HttpPostedFileBase ImageFile)
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
                    party.Image = convertedImage;
                }


            }
            party.IsDeleted = false;

            if (ModelState.IsValid)
            {

                status = partyBll.Create(party);
                if (status == true)
                {

                    ViewBag.Msg = "Party Successfully Added";
                    ModelState.Clear();
                    return View();
                }
                if (status == false)
                {

                    ViewBag.Msg = "Party Added Failed !";
                }

            }
            return View(party);
        }



        //Update Party  [Get Request]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Party party = partyBll.GetById(id);

            if (party == null)
            {
                return RedirectToAction("Error", "Home", null);
            }

            return View(party);
        }



        //Update Party Category [Post Request]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Party party, HttpPostedFileBase ImageFile, byte[] CurrentImage)
        {

            if (ImageFile == null)
            {

                party.Image = CurrentImage;
            }

            if (ImageFile != null)
            {
                bool isValidFormat = common.CheckImageFormat(ImageFile);
                if (isValidFormat == false)
                {
                    party.Image = CurrentImage;
                    ModelState.AddModelError("Image", "Only jpg , png , jpeg are allowed");
                }
                else
                {
                    party.Image = common.ConvertImage(ImageFile);
                }

            }

            if (ModelState.IsValid)
            {

                status = partyBll.Update(party);
                if (status == true)
                {
                    return RedirectToAction("ShowAll");
                }
                if (status == false)
                {

                    ViewBag.Msg = "Party Category Added Failed !";
                }

            }
            return View(party);
        }



        [HttpPost]
        //Delete Party [Post Request]
        public JsonResult Delete(int id)
        {
            status = partyBll.Delete(id);
            if (status)
            {
                return Json(1);
            }
            return Json(0);
        }



        //Show All Party
        public ActionResult ShowAll()
        {

            List<Party> listOfParty = partyBll.GetAll();
            return View(listOfParty);
        }


        //Show Party Detail
        public ActionResult Details(int? id)
        {
            Party party = partyBll.GetById(id);
            return PartialView("Details_Partial", party);
        }


        //Generating Random Category Code
        public JsonResult GetPartyCode()
        {
            string partyCode = partyBll.GetPartyCode();
            return Json(partyCode);
        }


        //Checking Party Email Availability
        public JsonResult CheckPartyEmail(string email,string type)
        {
            status = partyBll.CheckPartyEmail(email,type);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }
    }
}