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
    public class SalesDAL
    {
        SuperShopDbContext db = new SuperShopDbContext();
        internal double GetItemSalesPrice(int id)
        {
            Item item = db.Items.Find(id);
            double itemSalesPrice = item.SalesPrice;
            return itemSalesPrice;
        }

        internal bool Create(Sales sales)
        {
            db.Saleses.Add(sales);
            return db.SaveChanges() > 0;
        }

        internal List<Sales> GetSearchResult(SearchVM searchVM)
        {
            var listOfSales = db.Saleses.AsQueryable();
            if (searchVM.Code != null)
            {
                listOfSales = listOfSales.Where(m => m.Id == searchVM.Code).AsQueryable();
            }
            if (searchVM.OutletId != null)
            {
                listOfSales = listOfSales.Where(m => m.OutletId == searchVM.OutletId).AsQueryable();
            }
            if (searchVM.FromDate != null)
            {
                listOfSales = listOfSales.Where(m => m.SalesDate >= searchVM.FromDate).AsQueryable();
            }
            if (searchVM.ToDate != null)
            {
                listOfSales = listOfSales.Where(m => m.SalesDate <= searchVM.ToDate).AsQueryable();
            }
            return listOfSales.ToList();
        }

        internal Sales GetSalesDetail(int? id)
        {
            Sales sales = db.Saleses.SingleOrDefault(model=>model.Id==id && model.IsDeleted==false);
            return sales;
        }

        internal Sales GetLastId()
        {
           return  db.Saleses.Where(model=>model.IsDeleted==false).LastOrDefault();
        }

        internal List<Sales> GetAll()
        {
            List<Sales> listOfSales = db.Saleses.Where(model => model.IsDeleted == false).ToList();
            return listOfSales;
        }
    }
}