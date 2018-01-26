using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class SalesBLL
    {
        SalesDAL salesDal = new SalesDAL();
        bool status = false;
        internal double GetItemSalesPrice(int id)
        {
            double itemSalesPrice = salesDal.GetItemSalesPrice(id);
            return itemSalesPrice;
        }

        internal bool Create(Sales sales)
        {
            status = salesDal.Create(sales);
            return status;
        }

        internal SalesReceipt_ViewModel GetSalesDetail(int? id)
        {
            Sales sales = salesDal.GetSalesDetail(id);
            SalesReceipt_ViewModel salesReceiptVm = new SalesReceipt_ViewModel();
            if(sales != null)
            {
                salesReceiptVm.SalesNo = sales.Id;
                salesReceiptVm.SalesDate = sales.SalesDate.ToShortDateString();
                salesReceiptVm.Outlet = sales.Outlet.Name;
                salesReceiptVm.SoldBy = sales.Employee.Name;
                salesReceiptVm.CustomerName = sales.CustomerName;
                salesReceiptVm.ContactNo = sales.CustomerContact;
                salesReceiptVm.TotalPrice = Convert.ToDouble(sales.SubTotal);
                salesReceiptVm.GrandTotal = Convert.ToDouble(sales.Total);
                salesReceiptVm.Discount = Convert.ToDouble(sales.Discount);
                salesReceiptVm.VAT = Convert.ToDouble(sales.VAT);
                salesReceiptVm.SalesDetails = sales.SalesDetails;
            }
            
            return salesReceiptVm;
        }

        internal int GetLastId()
        {
            Sales sales = salesDal.GetLastId();
            int id = sales.Id;
            return id;
        }

        internal List<Sales> GetAll()
        {
            List<Sales> listOfSales = salesDal.GetAll();
            return listOfSales;

        }
    }
}