using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class CommonBLL
    {
        CommonDAL commonDal = new CommonDAL();

        internal int GetItemStock(int id)
        {
            List<PurchaseDetail> listOfPurchase = commonDal.GetListOfPurchase(id);
            List<SalesDetail> listOfSales = commonDal.GetListOfSales(id);
            int countOfPurchase = 0;
            int countOfSales = 0;
            int stock = 0;
            foreach(var item in listOfPurchase)
            {
                countOfPurchase = countOfPurchase + item.Quantity;
            }
            foreach (var item in listOfSales)
            {
                countOfSales = countOfSales + item.Quantity;
            }
            stock = countOfPurchase - countOfSales;
            if (stock <= 0)
            {
                return 0;
            }

            return stock;
        }
    }
}