using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    public class ExpenseItemsController : Controller
    {
        ExpenseItemBLL expenseItemBll = new ExpenseItemBLL();
        DropDownList dropDown = new DropDownList();
        bool status = false;

        //GET: Create Expense Item
        public ActionResult Create()
        {
            ViewBag.ExpenseItemCategoryId = dropDown.GetAllExpenseCategory();
            return View();
        }


        //POST: Create Expense Item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseItem expenseItem)
        {


            expenseItem.IsDeleted = false;

            if (ModelState.IsValid)
            {

                status = expenseItemBll.Create(expenseItem);
                if (status == true)
                {

                    ViewBag.Msg = "Expense Item Successfully Added";
                    ModelState.Clear();
                    ViewBag.ExpenseCategoryId = dropDown.GetAllExpenseCategory();
                    return View();
                }
                if (status == false)
                {

                    ViewBag.Msg = "ExpenseItem Category Added Failed";
                }

            }
            ViewBag.ExpenseCategoryId = dropDown.GetAllExpenseCategory();
            return View(expenseItem);
        }



        //GET: Update Expense Item
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            ExpenseItem ExpenseItem = expenseItemBll.GetById(id);

            if (ExpenseItem == null)
            {
                return RedirectToAction("Error", "Home", null);
            }

            ViewBag.ExpenseItemCategoryId = dropDown.GetAllExpenseCategoryById(id);
            return View(ExpenseItem);
        }



        //POST: Update ExpenseItem Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ExpenseItem expenseItem)
        {

            if (ModelState.IsValid)
            {

                status = expenseItemBll.Update(expenseItem);
                if (status == true)
                {
                    return RedirectToAction("ShowAll");
                }
                if (status == false)
                {

                    ViewBag.Msg = "Expense Item Added Failed";
                }

            }
            ViewBag.ExpenseItemCategoryId = dropDown.GetAllExpenseCategory();
            return View(expenseItem);
        }


        //Delete Expense Item
        [HttpPost]
        public JsonResult Delete(int id)
        {
            status = expenseItemBll.Delete(id);
            if (status)
            {
                return Json(1);
            }
            return Json(0);
        }



        //Show All Expense Item
        public ActionResult ShowAll()
        {

            List<ExpenseItem> listOfExpenseItem = expenseItemBll.GetAll();
            return View(listOfExpenseItem);
        }


        //Show Expense Item Detail
        public ActionResult Details(int? id)
        {
            ExpenseItem expenseItem = expenseItemBll.GetById(id);
            return PartialView("Details_Partial", expenseItem);
        }


        //Get All Parent Category
        public JsonResult GetParentCategories()
        {
            var listOfExpenseItem = expenseItemBll.GetParentCategories();

            return Json(listOfExpenseItem, JsonRequestBehavior.AllowGet);
        }


        //Generating Random Category Code
        public JsonResult GetExpenseItemCode()
        {
            string expenseItemCode = expenseItemBll.GetExpenseItemCode();
            return Json(expenseItemCode);
        }


        //Checking Expense Item Name Availability
        public JsonResult CheckExpenseItemName(string expenseItemName, int expenseCategory)
        {
            status = expenseItemBll.CheckExpenseItemName(expenseItemName, expenseCategory);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);


        }
    }
}