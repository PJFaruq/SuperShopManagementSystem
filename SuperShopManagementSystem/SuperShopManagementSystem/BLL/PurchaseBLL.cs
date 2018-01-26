using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class PurchaseBLL
    {
        PurchaseDAL purchaseDal = new PurchaseDAL();
        bool status = false;
        internal double GetItemPurchasePrice(int id)
        {
            double purchasePrice = purchaseDal.GetItemPurchasePrice(id);
            return purchasePrice;
        }

        internal bool Create(Purchase purchase)
        {
            status = purchaseDal.Create(purchase);
            return status;
        }

        internal PurchaseResultVM GetPurchaseDetail(int? id)
        {
            Purchase purchase = purchaseDal.GetPurchaseDetail(id);
            PurchaseResultVM purchaseResultVM = new PurchaseResultVM();
            if (purchase != null)
            {
                purchaseResultVM.PurchaseNo = purchase.Id.ToString();
                purchaseResultVM.PurchaseDate = purchase.PurchaseDate;
                purchaseResultVM.Supplier = purchase.Party.Name;
                purchaseResultVM.Outlet = purchase.Outlet.Name;
                purchaseResultVM.PurchaseBy = purchase.Employee.Name;
                purchaseResultVM.Remarks = purchase.Remarks;
                purchaseResultVM.PurchaseDetails = purchase.PurchaseDetails;
            }
            
            

            return purchaseResultVM;
        }

        internal List<Purchase> GetAll()
        {
            List<Purchase> purchase = purchaseDal.GetAll();
            return purchase;
        }

        internal List<Purchase> GetSearchResult(PurchaseSearchVM purchaseSearchVM)
        {
            List<Purchase> listOfPurchase = purchaseDal.GetSearchResult(purchaseSearchVM);
            return listOfPurchase;
        }
    }
}