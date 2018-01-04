using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SuperShopManagementSystem.Models;

namespace SuperShopManagementSystem.DAL
{
    public class ItemCategoryDAL
    {
        bool status = false;
        internal bool Create(ItemCategory itemCategory)
        {
            
            return status;
        }


        internal bool Update(ItemCategory itemCategory)
        {
            return status;
        }

        internal bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        internal List<ItemCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        internal ItemCategory GetById(int? id)
        {
            ItemCategory itemCategory = null;
            return itemCategory;
        }

        internal List<ItemCategory> Get(Expression<Func<ItemCategory ,bool>> predicate)
        {
            throw new NotImplementedException();
        }

        internal List<ItemCategory> Search(ItemCategory itemCategory)
        {
            throw new NotImplementedException();
        }
    }
}