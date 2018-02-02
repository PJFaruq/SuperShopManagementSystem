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
    public class PurchasesController : Controller
    {
        DropDownList dropdown = new DropDownList();
        PurchaseBLL purchaseBll = new PurchaseBLL();
        bool status = false;

        // GET:Create Purchases
        public ActionResult Create()
        {
            ViewBag.ItemId = dropdown.GetAllItem();
            ViewBag.OutletId = dropdown.GetAllOutlet();
            ViewBag.EmployeeId = dropdown.GetAllEmployee();
            ViewBag.PartyId = dropdown.GetAllSupplier();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post:Create Purchases
        public ActionResult Create(Purchase purchase)
        {
            if(ModelState.IsValid && purchase.PurchaseDetails!=null && purchase.PurchaseDetails.Count > 0)
            {
                purchase.IsDeleted = false;
                status = purchaseBll.Create(purchase);
                if (status == true)
                {
                    ViewBag.SuccessMsg = "Purchase Item Successfully";
                    ModelState.Clear();
                }
            }

            ViewBag.ItemId = dropdown.GetAllItem();
            ViewBag.OutletId = dropdown.GetAllOutlet();
            ViewBag.EmployeeId = dropdown.GetAllEmployee();
            ViewBag.PartyId = dropdown.GetAllSupplier();
            return View();
        }

        //Purchase Result
        public ActionResult PurchaseResult(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            PurchaseResultVM purchaseResultVM = purchaseBll.GetPurchaseDetail(id);
            if(purchaseResultVM == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(purchaseResultVM);
        }

        public JsonResult GetItemPurchasePrice(int id)
        {
            double purchasePrice = purchaseBll.GetItemPurchasePrice( id);
            return Json(purchasePrice, JsonRequestBehavior.AllowGet);
        }

        //Details of Purchase
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            PurchaseResultVM purchaseResultVM = purchaseBll.GetPurchaseDetail(id);
            return View(purchaseResultVM);
        }


        //Show All Purchases
        public ActionResult ShowAll()
        {
            List<Purchase> purchase = purchaseBll.GetAll();
            return View(purchase);
        }


        //Convert to PDF
        public ActionResult PurchaseReceiptPdf(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return new Rotativa.ActionAsPdf("PurchaseResult", new { id = id });
        }

    }
}