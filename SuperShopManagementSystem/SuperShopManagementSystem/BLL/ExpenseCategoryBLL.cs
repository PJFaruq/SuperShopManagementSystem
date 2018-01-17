using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class ExpenseCategoryBLL
    {
        bool status = false;
        ExpenseCategoryDAL expenseCategoryDal = new ExpenseCategoryDAL();
        internal bool Create(ExpenseCategory expenseCategory)
        {

            status = expenseCategoryDal.Create(expenseCategory);
            return status;
        }



        internal bool Update(ExpenseCategory expenseCategory)
        {
            status = expenseCategoryDal.Update(expenseCategory);
            return status;
        }

        internal bool Delete(int id)
        {
            status = expenseCategoryDal.Delete(id);
            return status;
        }

        internal ExpenseCategory GetById(int? id)
        {
            ExpenseCategory expenseCategory = expenseCategoryDal.GetById(id);
            return expenseCategory;
        }


        internal List<ExpenseCategory> GetAll()
        {
            List<ExpenseCategory> listOfExpenseCategory = expenseCategoryDal.GetAll();
            return listOfExpenseCategory;
        }

        Random randomCode = new Random();
        internal string GetCategoryCode()
        {
            string generatedCode = "";

            int code = randomCode.Next(001, 1000);

            generatedCode = code.ToString();
            if (generatedCode.Length == 1)
            {
                generatedCode = "C" + "0" + "0" + code;
            }
            if (generatedCode.Length == 2)
            {
                generatedCode = "C" + "0" + code;
            }
            if (generatedCode.Length == 3)
            {
                generatedCode = "C" + generatedCode;
            }


            List<ExpenseCategory> listOfCategoryCode = expenseCategoryDal.GetAllCode();
            if (listOfCategoryCode != null)
            {
                if (listOfCategoryCode.Count == 999)
                {
                    generatedCode = "Unable to Generate Code";
                }
                foreach (var item in listOfCategoryCode)
                {
                    if (generatedCode == item.Code)
                    {
                        return GetCategoryCode();
                    }
                }
            }
            return generatedCode;
        }

        internal bool CheckCategoryName(string categoryName)
        {
            status = expenseCategoryDal.CheckCategoryName(categoryName);
            return status;
        }

        internal List<ExpenseCategory> GetParentCategories()
        {
            List<ExpenseCategory> listOfExpenseCategory = expenseCategoryDal.GetParentCategories();
            return listOfExpenseCategory;
        }
    }
}