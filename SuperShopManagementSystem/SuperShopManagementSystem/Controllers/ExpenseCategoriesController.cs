using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    public class ExpenseCategoriesController : Controller
    {
        ExpenseCategoryBLL expenseCategoryBll = new ExpenseCategoryBLL();
        DropDownBLL dropDownBll = new DropDownBLL();
        bool status = false;
        Common common = new Common();

        //GET: Create Expense Category
        public ActionResult Create()
        {
            return View();
        }


        // POST: Create Expense Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseCategory expenseCategory)
        {

            expenseCategory.IsDeleted = false;

            if (ModelState.IsValid)
            {

                status = expenseCategoryBll.Create(expenseCategory);
                if (status == true)
                {

                    ViewBag.Msg = "Expense Category Successfully Added";
                    ModelState.Clear();
                    return View();
                }
                if (status == true)
                {

                    ViewBag.Msg = "Expense Category Added Failed";
                }

            }

            return View(expenseCategory);
        }

        //Update Item Category [Get Request]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            ExpenseCategory expenseCategory = expenseCategoryBll.GetById(id);

            if (expenseCategory == null)
            {
                return RedirectToAction("Error", "Home", null);
            }

            ViewBag.ParentId = dropDownBll.GetExpenseParentById(id);
            return View(expenseCategory);
        }



        //Update Item Category [Post Request]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ExpenseCategory ExpenseCategory)
        {
            if (ModelState.IsValid)
            {
                status = expenseCategoryBll.Update(ExpenseCategory);
                if (status)
                {
                    return RedirectToAction("ShowAll");
                }
            }

            ViewBag.ParentId = dropDownBll.GetExpenseParentById(ExpenseCategory.Id);
            return View(ExpenseCategory);
            
        }



        [HttpPost]
        //Delete Item Category [Post Request]
        public JsonResult Delete(int id)
        {
            status = expenseCategoryBll.Delete(id);
            if (status)
            {
                return Json(1);
            }
            return Json(0);
        }



        //Show All Expense Category
        public ActionResult ShowAll()
        {

            List<ExpenseCategory> listOfExpenseCategory = expenseCategoryBll.GetAll();
            return View(listOfExpenseCategory);
        }


        //Get All Parent Category
        public JsonResult GetParentCategories()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            var listOfExpenseCategory = expenseCategoryBll.GetParentCategories();
            var jsonData = listOfExpenseCategory.Select(model => new { Id = model.Id, Name = model.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        //Generating Random Category Code
        public JsonResult GetCategoryCode()
        {
            string categoryCode = expenseCategoryBll.GetCategoryCode();
            return Json(categoryCode);
        }


        //Checking Category Name Availability
        public JsonResult CheckCategoryName(string data)
        {
            status = expenseCategoryBll.CheckCategoryName(data);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);


        }
    }
}
