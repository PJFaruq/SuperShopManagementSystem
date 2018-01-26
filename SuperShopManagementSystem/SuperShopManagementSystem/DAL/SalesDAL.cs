using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.DatabaseContex;
using SuperShopManagementSystem.Models.Operation;
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