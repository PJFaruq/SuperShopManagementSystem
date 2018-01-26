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

        public SelectList GetAllItem()
        {
            SelectList selectListOfItem = dropDownbll.GetAllItem();
            return selectListOfItem;
        }

        internal SelectList GetAllExpenseItem()
        {
            SelectList selectListOfItem = dropDownbll.GetAllExpenseItem();
            return selectListOfItem;
        }

        public SelectList GetAllItemCategoryById(int?id)
        {
            SelectList selectListOfItemCategory = dropDownbll.GetAllItemCategoryById(id);
            return selectListOfItemCategory;
        }

        public SelectList GetAllOutlet()
        {
            SelectList selectListOfOutlet = dropDownbll.GetAllOutlet();
            return selectListOfOutlet;
        }

        public SelectList GetAllEmployee()
        {
            SelectList selectListOfEmployee = dropDownbll.GetAllEmployee();
            return selectListOfEmployee;
        }

        internal SelectList GetAllOrganization()
        {
            SelectList listOfOrganization = dropDownbll.GetAllOrganization();
            return listOfOrganization;
        }

        internal SelectList GetAllExpenseCategory()
        {
            SelectList selectListOfExpenseCategory = dropDownbll.GetAllExpenseCategory();
            return selectListOfExpenseCategory;
        }

        internal dynamic GetAllExpenseCategoryById(int? id)
        {
            SelectList selectListOfExpenseCategory = dropDownbll.GetAllExpenseCategoryById(id);
            return selectListOfExpenseCategory;
        }

        public SelectList GetAllSupplier()
        {
            SelectList selectlistOfSupplier = dropDownbll.GetAllSupplier();
            return selectlistOfSupplier;
        }
    }
}