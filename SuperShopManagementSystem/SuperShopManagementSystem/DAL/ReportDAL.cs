using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.DatabaseContex;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;

namespace SuperShopManagementSystem.DAL
{
    public class ReportDAL
    {
        private SuperShopDbContext db = new SuperShopDbContext();
        internal List<PurchaseDetail> GetPurchaseItemByOutletId(int? outletId)
        {
            List<PurchaseDetail> listOfPurchaseItem = db.PurchaseDetails.Where(m => m.IsDeleted == false && m.Purchase.OutletId == outletId && m.Purchase.IsDeleted == false).DistinctBy(m => m.ItemId).ToList();
            return listOfPurchaseItem;
        }

        internal List<SalesDetail> GetSalesItemByOutletId(int? outletId)
        {
            List<SalesDetail> listOfSalesItem = db.SalesDetails.Where(m => m.IsDeleted == false && m.Sales.OutletId == outletId && m.Sales.IsDeleted==false).ToList();
            return listOfSalesItem;
        }

        internal List<Sales> GetSalesSearchResult(SearchVM salesSearchVM)
        {
            var listOfSales = db.Saleses.AsQueryable();
            if (salesSearchVM.Code != null)
            {
                listOfSales = listOfSales.Where(m => m.Id == salesSearchVM.Code).AsQueryable();
            }
            if (salesSearchVM.OutletId != null)
            {
                listOfSales = listOfSales.Where(m => m.OutletId == salesSearchVM.OutletId).AsQueryable();
            }
            if (salesSearchVM.FromDate != null)
            {
                listOfSales = listOfSales.Where(m => m.SalesDate >= salesSearchVM.FromDate).AsQueryable();
            }
            if (salesSearchVM.ToDate != null)
            {
                listOfSales = listOfSales.Where(m => m.SalesDate <= salesSearchVM.ToDate).AsQueryable();
            }
            return listOfSales.ToList();
        }

        internal List<Expense> GetExpenseSearchResult(SearchVM expenseSearchVM)
        {
            var listOfExpense = db.Expenses.AsQueryable();
            if (expenseSearchVM.Code != null)
            {
                listOfExpense = listOfExpense.Where(m => m.Id == expenseSearchVM.Code).AsQueryable();
            }
            if (expenseSearchVM.OutletId != null)
            {
                listOfExpense = listOfExpense.Where(m => m.OutletId == expenseSearchVM.OutletId).AsQueryable();
            }
            if (expenseSearchVM.FromDate != null)
            {
                listOfExpense = listOfExpense.Where(m => m.Date >= expenseSearchVM.FromDate).AsQueryable();
            }
            if (expenseSearchVM.ToDate != null)
            {
                listOfExpense = listOfExpense.Where(m => m.Date <= expenseSearchVM.ToDate).AsQueryable();
            }
            return listOfExpense.ToList();
        }
    }
}