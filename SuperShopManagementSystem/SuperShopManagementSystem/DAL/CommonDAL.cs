using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperShopManagementSystem.Models.DatabaseContex;
using SuperShopManagementSystem.Models.Operation;

namespace SuperShopManagementSystem.DAL
{
    public class CommonDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        internal List<PurchaseDetail> GetListOfPurchase(int id)
        {
            List<PurchaseDetail> listOfPurchase = db.PurchaseDetails.Where(model => model.ItemId == id && model.IsDeleted==false).ToList();
            return listOfPurchase;
        }

        internal List<SalesDetail> GetListOfSales(int id)
        {
            List<SalesDetail> listOfPurchase = db.SalesDetails.Where(model => model.ItemId == id && model.IsDeleted==false).ToList();
            return listOfPurchase;
        }
    }
}