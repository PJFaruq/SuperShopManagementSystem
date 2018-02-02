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
    public class SalesController : Controller
    {
        SalesBLL salesBll = new SalesBLL();
        Common common = new Common();
        DropDownList dropdown = new DropDownList();
        bool status = false;
        // GET:Create Sales
        public ActionResult Create()
        {
            ViewBag.EmployeeId = dropdown.GetAllEmployee();
            ViewBag.OutletId = dropdown.GetAllOutlet();
            ViewBag.ItemId = dropdown.GetAllItem();
            return View();
        }


        //POST: Create Sales
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post:Create Saless
        public ActionResult Create(Sales sales)
        {
            if (ModelState.IsValid && sales.SalesDetails != null && sales.SalesDetails.Count > 0)
            {
                sales.IsDeleted = false;
                status = salesBll.Create(sales);
                if (status == true)
                {
                    ViewBag.SuccessMsg = "Sales Item Successfully";
                    ModelState.Clear();
                }
            }

            ViewBag.ItemId = dropdown.GetAllItem();
            ViewBag.OutletId = dropdown.GetAllOutlet();
            ViewBag.EmployeeId = dropdown.GetAllEmployee();
            ViewBag.PartyId = dropdown.GetAllSupplier();
            return View();
        }

        public ActionResult SalesReceiptPdf(int?id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return new Rotativa.ActionAsPdf("SalesReceipt",new {id=id });
        }


        //Sales Receipt
        public ActionResult SalesReceipt(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            
            SalesReceipt_ViewModel salesReceiptVM = salesBll.GetSalesDetail(id);
            if (salesReceiptVM == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(salesReceiptVM);
        }

       

        //Get Item Sales Price
        public JsonResult GetItemSalesPrice(int id)
        {
            double itemSalesPrice = salesBll.GetItemSalesPrice(id);
            return Json(itemSalesPrice, JsonRequestBehavior.AllowGet);
        }



        //Get Item Stock
        public JsonResult GetItemStock(int id)
        {
            int numberOfStock = common.GetItemStock(id);
            return Json(numberOfStock, JsonRequestBehavior.AllowGet);
        }


        //Show All Sales
        public ActionResult ShowAll()
        {
            List<Sales> listOfSales = salesBll.GetAll();
            return View(listOfSales);
        }

        //Details of Purchase
        public ActionResult Details(int ? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            SalesReceipt_ViewModel salesReceiptVM = salesBll.GetSalesDetail(id);
            return View(salesReceiptVM);
        }
    }
}