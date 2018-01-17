using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperShopManagementSystem.BLL;

namespace SuperShopManagementSystem.Controllers
{
    public class ItemsController : Controller
    {
        ItemBLL itemBll = new ItemBLL();
        DropDownList dropDown = new DropDownList();
        bool status = false;

        //GET: Create Item 
        public ActionResult Create()
        {
            ViewBag.ItemCategoryId = dropDown.GetAllItemCategory();
                return View();
        }


        //POST: Create Item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item Item, HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please Upload an Image");
            }


            bool isValidFormat = itemBll.CheckImageFormat(ImageFile);
            if (isValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg , png , jpeg are allowed");
            }

            Item.IsDeleted = false;

            if (ModelState.IsValid)
            {

                status = itemBll.Create(Item, ImageFile);
                if (status == true)
                {

                    ViewBag.Msg = "Item Category Successfully Added";
                    ModelState.Clear();
                    ViewBag.ItemCategoryId = dropDown.GetAllItemCategory();
                    return View();
                }
                if (status == false)
                {
                    
                    ViewBag.Msg = "Item Category Added Failed";
                }

            }
            ViewBag.ItemCategoryId = dropDown.GetAllItemCategory();
            return View(Item);
        }



        //Update Item  [Get Request]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Item Item = itemBll.GetById(id);

            if (Item == null)
            {
                return RedirectToAction("Error", "Home", null);
            }

            ViewBag.ItemCategoryId = dropDown.GetAllItemCategoryById(id);
            return View(Item);
        }



        //Update Item Category [Post Request]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Item item, HttpPostedFileBase ImageFile,byte[] CurrentImage)
        {

            if (ImageFile == null)
            {
                item.Image = CurrentImage;
            }

            if (ImageFile != null)
            {
                bool isValidFormat = itemBll.CheckImageFormat(ImageFile);
                if (isValidFormat == false)
                {
                    item.Image = CurrentImage;
                    ModelState.AddModelError("Image", "Only jpg , png , jpeg are allowed");
                }
                item.Image = new byte[ImageFile.ContentLength];
                ImageFile.InputStream.Read(item.Image, 0, ImageFile.ContentLength);
            }

            if (ModelState.IsValid)
            {

                status = itemBll.Update(item);
                if (status == true)
                {
                    return RedirectToAction("ShowAll");
                }
                if (status == false)
                {

                    ViewBag.Msg = "Item Category Added Failed";
                }

            }
            ViewBag.ItemCategoryId = dropDown.GetAllItemCategory();
            return View(item);
        }



        [HttpPost]
        //Delete Item [Post Request]
        public JsonResult Delete(int id)
        {
            status = itemBll.Delete(id);
            if (status)
            {
                return Json(1);
            }
            return Json(0);
        }



        //Show All Item
        public ActionResult ShowAll()
        {

            List<Item> listOfItem = itemBll.GetAll();
            return View(listOfItem);
        }


        //Show Item Detail
        public ActionResult Details(int?id)
        {
            Item item = itemBll.GetById(id);
            return PartialView("Details_Partial", item);
        }


        //Get All Parent Category
        public JsonResult GetParentCategories()
        {
            var listOfItem = itemBll.GetParentCategories();

            return Json(listOfItem, JsonRequestBehavior.AllowGet);
        }


        //Generating Random Category Code
        public JsonResult GetItemCode()
        {
            string itemCode = itemBll.GetItemCode();
            return Json(itemCode);
        }


        //Checking Item Name Availability
        public JsonResult CheckItemName(string itemName,int itemCategory)
        {
            status = itemBll.CheckItemName(itemName, itemCategory);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);


        }

    }
}