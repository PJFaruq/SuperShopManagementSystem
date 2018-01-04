using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Create(ItemCategory itemCategory)
        {

            ItemCategoryBLL itemCategoryBll = new ItemCategoryBLL();
            bool status = false;
            status = itemCategoryBll.Create(itemCategory);
            return View();
        }

        //Update Item Category [Get Request]
        public ActionResult Update(int ?Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Error", "Home", null);
            }
            ItemCategory itemCategory = new ItemCategory();
            //ItemCategory itemCategory = itemCategoryBll.GetById(Id);
            //Test Value
            itemCategory.Id = 1;
            itemCategory.Name = "Electronics";
            itemCategory.Code = "E001";
            itemCategory.Description = "This is Electronics Product";

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

        //Delete Item Category [Get Request]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Error", "Home", null);
            }

            ItemCategory itemCategory = itemCategoryBll.GetById(Id);

            if (itemCategory == null)
            {
                return RedirectToAction("Error", "Home", null);
            }

            return View(itemCategory);
        }

        //Delete Item Category [Post Request]
        public ActionResult Delete(int Id)
        {
            status = itemCategoryBll.Delete(Id);
            return View();
        }

        //Get All Category Item
        public ActionResult ShowAll()
        {
            //List<ItemCategory> listOfItemCategory = itemCategoryBll.GetAll();
            return View();
        }
    }
}