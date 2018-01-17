using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class ExpenseItemBLL
    {
            bool status = false;
            ExpenseItemDAL expenseItemDal = new ExpenseItemDAL();
            internal bool Create(ExpenseItem expenseItem)
            {
                status = expenseItemDal.Create(expenseItem);
                return status;
            }

            internal bool Update(ExpenseItem expenseItem)
            {
                status = expenseItemDal.Update(expenseItem);
                return status;
            }

            internal bool Delete(int id)
            {
                status = expenseItemDal.Delete(id);
                return status;
            }

            internal ExpenseItem GetById(int? id)
            {
                ExpenseItem expenseItem = expenseItemDal.GetById(id);
                return expenseItem;
            }

            internal List<ExpenseItem> GetAll()
            {
                List<ExpenseItem> listOfExpenseItem = expenseItemDal.GetAll();
                return listOfExpenseItem;
            }

            Random randomCode = new Random();
            internal string GetExpenseItemCode()
            {
                string generatedCode = "";

                int code1 = randomCode.Next(100, 1000);
                int code2 = randomCode.Next(10000000, 100000000);

                generatedCode = "EI" + code1.ToString() + "-" + code2.ToString();

                List<ExpenseItem> listOfExpenseItemCode = expenseItemDal.GetAllCode();
                if (listOfExpenseItemCode != null)
                {

                    foreach (var expenseItem in listOfExpenseItemCode)
                    {
                        if (generatedCode == expenseItem.Code)
                        {
                            return GetExpenseItemCode();
                        }
                    }
                }
                return generatedCode;
            }

            internal bool CheckExpenseItemName(string expenseItemName, int expenseItemCategory)
            {
                status = expenseItemDal.CheckExpenseItemName(expenseItemName, expenseItemCategory);
                return status;
            }

            internal object GetParentCategories()
            {
                throw new NotImplementedException();
            }
        
    }
}