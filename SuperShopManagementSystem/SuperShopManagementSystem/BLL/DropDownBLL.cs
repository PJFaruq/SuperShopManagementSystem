using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;

namespace SuperShopManagementSystem.BLL
{

    public class DropDownBLL
    {
        DropDownDAL dropDownDal=new DropDownDAL();
        internal SelectList GetAllItemCategory()
        {
            SelectList selectListOfItemCategory = dropDownDal.GetAllItemCategory();
            return selectListOfItemCategory;
        }
        internal SelectList GetAllItemCategoryById(int? id)
        {
            SelectList selectListOfItemCategory = dropDownDal.GetAllItemCategoryById(id);
            return selectListOfItemCategory;
        }

        internal SelectList GetAllExpenseCategory()
        {
            SelectList selectListOfExpenseCategory = dropDownDal.GetAllExpenseCategory();
            return selectListOfExpenseCategory;
        }

        internal SelectList GetAllExpenseCategoryById(int? id)
        {
            SelectList selectListOfExpenseCategory = dropDownDal.GetAllExpenseCategoryById(id);
            return selectListOfExpenseCategory;
        }
    }
}