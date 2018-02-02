using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.DatabaseContex;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.DAL
{
    public class PurchaseDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        bool status = false;
        internal double GetItemPurchasePrice(int id)
        {
            Item item = db.Items.Find(id);
            double purchasePrice = item.PurchasePrice;
            return purchasePrice;
        }

        internal bool Create(Purchase purchase)
        {
            db.Purchases.Add(purchase);
            return db.SaveChanges() > 0;
        }

        internal Purchase GetPurchaseDetail(int? id)
        {
            Purchase purchase = db.Purchases.SingleOrDefault(model => model.Id == id && model.IsDeleted == false);
            return purchase;

        }

        internal List<Purchase> GetAll()
        {
            List<Purchase> purchase = db.Purchases.Where(model => model.IsDeleted == false).ToList();
            return purchase;
        }

        internal List<Purchase> GetSearchResult(SearchVM purchaseSearchVM)
        {
            var listOfPurchase = db.Purchases.AsQueryable();
            if (purchaseSearchVM.Code!=null)
            {
                listOfPurchase = listOfPurchase.Where(m => m.Id == purchaseSearchVM.Code).AsQueryable();
            }
            if (purchaseSearchVM.OutletId != null)
            {
                listOfPurchase = listOfPurchase.Where(m => m.OutletId == purchaseSearchVM.OutletId).AsQueryable();
            }
            if (purchaseSearchVM.FromDate!=null)
            {
                listOfPurchase = listOfPurchase.Where(m => m.PurchaseDate >=purchaseSearchVM.FromDate).AsQueryable();
            }
            if (purchaseSearchVM.ToDate!=null)
            {
                listOfPurchase = listOfPurchase.Where(m => m.PurchaseDate <= purchaseSearchVM.ToDate).AsQueryable();
            }
            return listOfPurchase.ToList();
        }
    }
}