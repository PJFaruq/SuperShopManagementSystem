using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    public class ExpensesController : Controller
    {
        Common common = new Common();
        DropDownList dropdown = new DropDownList();
        ExpenseBLL expenseBll = new ExpenseBLL();
        bool status = false;
        // GET:Create Expense
        public ActionResult Create()
        {
            ViewBag.EmployeeId = dropdown.GetAllEmployee();
            ViewBag.OutletId = dropdown.GetAllOutlet();
            ViewBag.ItemId = dropdown.GetAllExpenseItem();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post:Create Expenses
        public ActionResult Create(Expense expense)
        {
            if (ModelState.IsValid && expense.ExpenseDetails != null && expense.ExpenseDetails.Count > 0)
            {
                expense.IsDeleted = false;
                status = expenseBll.Create(expense);
                if (status == true)
                {
                    ViewBag.SuccessMsg = "Expense Item Successfully";
                    ModelState.Clear();
                }
            }

            ViewBag.ItemId = dropdown.GetAllItem();
            ViewBag.OutletId = dropdown.GetAllOutlet();
            ViewBag.EmployeeId = dropdown.GetAllEmployee();
            ViewBag.PartyId = dropdown.GetAllSupplier();
            return View();
        }

        //Expense Result
        public ActionResult ExpenseResult(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ExpenseResultVM expenseResultVM = expenseBll.GetExpenseDetail(id);
            if (expenseResultVM == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(expenseResultVM);
        }

        //Details of Expense
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ExpenseResultVM expenseResultVM = expenseBll.GetExpenseDetail(id);
            return View(expenseResultVM);
        }


        //Show All Expenses
        public ActionResult ShowAll()
        {
            List<Expense> expense = expenseBll.GetAll();
            return View(expense);
        }


        //Convert to PDF
        public ActionResult ExpenseReceiptPdf(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return new Rotativa.ActionAsPdf("ExpenseResult", new { id = id });
        }
    }
}