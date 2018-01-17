using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.DatabaseContex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SuperShopManagementSystem.Controllers
{
    public class ItemCategoriesController : Controller
    {
        ItemCategoryBLL itemCategoryBll = new ItemCategoryBLL();
        bool status = false;

        // Create Item Category [Get Request]
        public ActionResult Create()
        {
            return View();
        }


        // Create Item Category [Post Request]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCategory itemCategory,HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please Upload an Image");
            }


            bool isValidFormat = itemCategoryBll.CheckImageFormat(ImageFile);
            if (isValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg , png , jpeg are allowed");
            }

            itemCategory.IsDeleted = false;

            if (ModelState.IsValid)
            {
                
                status = itemCategoryBll.Create(itemCategory, ImageFile);
                if (status == true)
                {

                    ViewBag.Msg = "Item Category Successfully Added";
                    ModelState.Clear();
                    return View();
                }
                if (status == true)
                {

                    ViewBag.Msg = "Item Category Added Failed";
                }

            }
            
            return View(itemCategory);
        }



        //Update Item Category [Get Request]
        public ActionResult Update(int ?id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            ItemCategory itemCategory = itemCategoryBll.GetById(id);

            if (itemCategory == null)
            {
                return RedirectToAction("Error", "Home", null);
            }


            return View(itemCategory);
        }



        //Update Item Category [Post Request]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ItemCategory itemCategory)
        {
            status = itemCategoryBll.Update(itemCategory);
            return View();
        }



        [HttpPost]
        //Delete Item Category [Post Request]
        public JsonResult Delete(int id)
        {
            status = itemCategoryBll.Delete(id);
            if (status)
            {
                return Json(1);
            }
            return Json(0);
        }



        //Get All Category Item
        public ActionResult ShowAll()
        {

            List<ItemCategory> listOfItemCategory = itemCategoryBll.GetAll();
            //db.Configuration.ProxyCreationEnabled = false;
            //var jsonDataList = listOfItemCategory.Select(model => new { Name = model.Name, Code = model.Code, Description = model.Description, PCategory=model.Parent.Name });
            //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //javaScriptSerializer.MaxJsonLength = Int32.MaxValue;
            //string jsonData = javaScriptSerializer.Serialize(jsonDataList);
            //return Json(jsonData, JsonRequestBehavior.AllowGet);
            return View(listOfItemCategory);
        }


        //Get All Parent Category
        public JsonResult GetParentCategories()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            var listOfItemCategory = itemCategoryBll.GetParentCategories();
            var jsonData = listOfItemCategory.Select(model => new { Id = model.Id, Name = model.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        //Generating Random Category Code
        public JsonResult GetCategoryCode()
        {
            string categoryCode=itemCategoryBll.GetCategoryCode();
            return Json(categoryCode);
        }


        //Checking Category Name Availability
        public JsonResult CheckCategoryName(string data)
        {
             status =itemCategoryBll.CheckCategoryName(data);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);


        }
    }


}