using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;

namespace SuperShopManagementSystem.BLL
{
    public class ItemCategoryBLL
    {
        bool status = false;
        ItemCategoryDAL itemCategoryDal = new ItemCategoryDAL();
        internal bool Create(ItemCategory itemCategory)
        {   
            status = itemCategoryDal.Create(itemCategory);
            return status;
        }



        internal bool Update(ItemCategory itemCategory)
        {
            status = itemCategoryDal.Update(itemCategory);
            return status;
        }

        internal bool Delete(int id)
        {
            status = itemCategoryDal.Delete(id);
            return status;
        }

        internal ItemCategory GetById(int? id)
        {
            ItemCategory itemCategory = itemCategoryDal.GetById(id);
            return itemCategory;
        }

        internal List<ItemCategory> GetAll()
        {
            List<ItemCategory> listOfItemCategory = itemCategoryDal.GetAll();
            return listOfItemCategory;
        }
    }
}