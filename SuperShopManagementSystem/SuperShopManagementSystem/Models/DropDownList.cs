using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperShopManagementSystem.BLL;

namespace SuperShopManagementSystem.Models
{
    public class DropDownList
    {
         DropDownBLL dropDownbll=new DropDownBLL();
        public SelectList GetAllItemCategory()
        {
            SelectList selectListOfItemCategory = dropDownbll.GetAllItemCategory();
            return selectListOfItemCategory;
        }
        public SelectList GetAllItemCategoryById(int?id)
        {
            SelectList selectListOfItemCategory = dropDownbll.GetAllItemCategoryById(id);
            return selectListOfItemCategory;
        }

        internal dynamic GetAllExpenseCategory()
        {
            SelectList selectListOfExpenseCategory = dropDownbll.GetAllExpenseCategory();
            return selectListOfExpenseCategory;
        }

        internal dynamic GetAllExpenseCategoryById(int? id)
        {
            SelectList selectListOfExpenseCategory = dropDownbll.GetAllExpenseCategoryById(id);
            return selectListOfExpenseCategory;
        }
    }
}