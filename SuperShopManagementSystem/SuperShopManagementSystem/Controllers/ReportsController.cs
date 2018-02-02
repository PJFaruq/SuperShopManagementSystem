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
    public class ReportsController : Controller
    {
        DropDownList dropdown = new DropDownList();
        PurchaseBLL purchaseBll = new PurchaseBLL();
        ReportBLL reportBll = new ReportBLL();
        // GET: Income Report
        public ActionResult Income()
        {
            ViewBag.OutletId = dropdown.GetAllOutlet();
            return View();
        }

        //POST: Income Report
        static IncomeReportVM listOfIncomeForPdf = new IncomeReportVM();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Income(SearchVM searchVM)
        {
            IncomeReportVM listOfIncome = reportBll.GetSearchResult(searchVM);
            listOfIncomeForPdf = listOfIncome;
            ViewBag.OutletId = dropdown.GetAllOutlet();
            return View(listOfIncome);
        }


        //Income Report Without Layout
        public ActionResult IncomeReport()
        {
            if (listOfIncomeForPdf == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(listOfIncomeForPdf);
        }

        //Income Report For PDF
        public ActionResult IncomeReportPdf()
        {
            return new Rotativa.ActionAsPdf("IncomeReport") {
                PageSize = Rotativa.Options.Size.A4
            };
        }


        //GET: Stock Report
        public ActionResult Stock()
        {
            ViewBag.OutletId = dropdown.GetAllOutlet();
            return View();
        }


        //POST: Stock Report
        static List<StockReportVM> listOfStockForPdf = new List<StockReportVM>();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Stock(int?OutletId)
        {
            List<StockReportVM> listOfStockReport = reportBll.GetStockReport(OutletId);
            listOfStockForPdf = listOfStockReport;
            ViewBag.OutletId = dropdown.GetAllOutlet();
            return View(listOfStockReport);
        }


        //Stock Report Without Layout
        public ActionResult StockReport()
        {
            if (listOfStockForPdf == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(listOfStockForPdf);
        }


        //Stock Report For PDF
        public ActionResult StockReportPdf()
        {
            if (listOfStockForPdf.Count <= 0)
            {
                return RedirectToAction("Stock");
            }
            return new Rotativa.ActionAsPdf("StockReport")
            {
                PageSize = Rotativa.Options.Size.A4
            };
        }

        //GET: Sales Report
        public ActionResult Sales()
        {
            ViewBag.OutletId = dropdown.GetAllOutlet();
            return View();
        }


        //POST: Sales Report
        static List<Sales> listOfSalesForPdf = new List<Sales>();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sales(SearchVM salesSearchVM)
        {
            List<Sales> listOfSales = reportBll.GetSalesSearchResult(salesSearchVM);
            listOfSalesForPdf = listOfSales;
            ViewBag.OutletId = dropdown.GetAllOutlet();
            return View(listOfSales);
        }


        //Sales Report Without Layout
        public ActionResult SalesReport()
        {
            if (listOfSalesForPdf == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(listOfSalesForPdf);
        }

        //Sales Report For PDF
        public ActionResult SalesReportPdf()
        {
            return new Rotativa.ActionAsPdf("SalesReport")
            {
                PageSize = Rotativa.Options.Size.A4
            };
        }


        //GET: Expense Report
        public ActionResult Expense()
        {
            ViewBag.OutletId = dropdown.GetAllOutlet();
            return View();
        }


        //POST: Expense Report
        static List<Expense> listOfExpenseForPdf = new List<Expense>();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Expense(SearchVM expenseSearchVM)
        {
            List<Expense> listOfExpense = reportBll.GetExpenseSearchResult(expenseSearchVM);
            listOfExpenseForPdf = listOfExpense;
            ViewBag.OutletId = dropdown.GetAllOutlet();
            return View(listOfExpense);
        }


        //Expense Report Without Layout
        public ActionResult ExpenseReport()
        {
            if (listOfExpenseForPdf == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(listOfExpenseForPdf);
        }

        //Expense Report For PDF
        public ActionResult ExpenseReportPdf()
        {
            return new Rotativa.ActionAsPdf("ExpenseReport")
            {
                PageSize = Rotativa.Options.Size.A4
            };
        }


        //GET: Purchase Report
        public ActionResult Purchase()
        {
            ViewBag.OutletId = dropdown.GetAllOutlet();
            return View();
        }


        //POST: Purchase Report
        static List<Purchase> listOfPurchaseForPdf = new List<Purchase>();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Purchase(SearchVM purchaseSearchVM)
        {
            List<Purchase> listOfPurchase = purchaseBll.GetSearchResult(purchaseSearchVM);
            listOfPurchaseForPdf = listOfPurchase;
            ViewBag.OutletId = dropdown.GetAllOutlet();
            return View(listOfPurchase);
        }


        //Purchase Report Without Layout
        public ActionResult PurchaseReport()
        {
            if (listOfPurchaseForPdf == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(listOfPurchaseForPdf);
        }

        //Purchase Report For PDF
        public ActionResult PurchaseReportPdf()
        {
            return new Rotativa.ActionAsPdf("PurchaseReport")
            {
                PageSize = Rotativa.Options.Size.A4
            };
        }
    }
}