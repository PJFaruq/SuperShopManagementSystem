using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;

namespace SuperShopManagementSystem.BLL
{
    public class ReportBLL
    {
        PurchaseDAL purchaseDal = new PurchaseDAL();
        SalesDAL saleDal = new SalesDAL();
        ReportDAL reportDal = new ReportDAL();
        Common common = new Common();
        ItemCategoryDAL itemCategoryDal = new ItemCategoryDAL();
        ItemDAL itemDal = new ItemDAL();
        internal IncomeReportVM GetSearchResult(SearchVM searchVM)
        {
            List<Purchase> listOfPurchase = purchaseDal.GetSearchResult(searchVM);
            List<Sales> listOfSales = saleDal.GetSearchResult(searchVM);
            
            IncomeReportVM incomeReportVM = new IncomeReportVM();
            decimal totalPurchase = 0;
            decimal totalSales = 0;
            if (listOfPurchase != null)
            {
                foreach (var purchase in listOfPurchase)
                {
                    totalPurchase = totalPurchase + purchase.Total;
                }
            }

            if (listOfSales != null)
            {
                foreach (var sales in listOfSales)
                {
                    totalSales = totalSales + sales.Total;
                }
            }
            incomeReportVM.TotalPurchase = totalPurchase;
            incomeReportVM.TotalSales = totalSales;
            incomeReportVM.TotalProfit = totalSales - totalPurchase;
            incomeReportVM.Sales = listOfSales;
            incomeReportVM.Purchase = listOfPurchase;

            return incomeReportVM;

        }
        
        internal List<StockReportVM> GetStockReport(int? outletId)
        {
            List<StockReportVM> listOfStockReportVM = new List<StockReportVM>();
            int count = 0;
            List<PurchaseDetail> listOfPurchaseItem = reportDal.GetPurchaseItemByOutletId(outletId);
            foreach(var item in listOfPurchaseItem)
            {
                StockReportVM stockReportVM = new StockReportVM();
                count++;
                stockReportVM.ItemName = item.Item.Name;
                stockReportVM.StockQuantiy = common.GetItemStock(item.ItemId);
                stockReportVM.AvgPrice = item.Price;
                stockReportVM.CategoryPath = GetCategoryPath(item.ItemId);
                stockReportVM.SerialNo = count;
                listOfStockReportVM.Add(stockReportVM);
            }
            return listOfStockReportVM;
        }

        internal string GetCategoryPath(int id)
        {
            Item item = itemDal.GetById(id);
            int itemCategoryId = item.ItemCategoryId;
            
            ItemCategory itemCategory = itemCategoryDal.GetById(itemCategoryId);
            string CategoryPath = itemCategory.Name+">"+ item.Name ;
            int? parentId = itemCategory.ParentId;
             while (parentId != null)
            {
                ItemCategory itemCategory1 = itemCategoryDal.GetById(parentId);
                if (itemCategory1 != null)
                {
                    CategoryPath = itemCategory1.Name + ">" + CategoryPath;
                    parentId = itemCategory1.ParentId;
                }
                else
                {
                    parentId = null;
                }
                
                
            }
            return CategoryPath;
        }

        internal List<Sales> GetSalesSearchResult(SearchVM salesSearchVM)
        {
            List<Sales> listOfSales = reportDal.GetSalesSearchResult(salesSearchVM);
            return listOfSales;
        }

        internal List<Expense> GetExpenseSearchResult(SearchVM expenseSearchVM)
        {
            List<Expense> listOfExpense = reportDal.GetExpenseSearchResult(expenseSearchVM);
            return listOfExpense;
        }
    }
}