using System;
using System.Collections.Generic;
using System.IO;
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
        internal bool Create(ItemCategory itemCategory, HttpPostedFileBase ImageFile)
        {
            itemCategory.Image = new byte[ImageFile.ContentLength];
            ImageFile.InputStream.Read(itemCategory.Image, 0, ImageFile.ContentLength);
            
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

        internal bool CheckImageFormat(HttpPostedFileBase imageFile)
        {
            if (imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName).ToLower();
                var fileName = Path.GetFileName(imageFile.FileName);

                var allowExtension = new[]
                {
                         ".jpg",".png",".jpeg"
                    };
                if (allowExtension.Contains(extension))
                {
                    status = true;
                } 
            }
            return status;
        }

        internal List<ItemCategory> GetAll()
        {
            List<ItemCategory> listOfItemCategory = itemCategoryDal.GetAll();
            return listOfItemCategory;
        }

        Random randomCode = new Random();
        internal string GetCategoryCode()
        {
            string generatedCode = "";
            
            int code = randomCode.Next(001, 1000);
            
             generatedCode =code.ToString();
            if (generatedCode.Length ==1)
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
            

            List<ItemCategory> listOfCategoryCode = itemCategoryDal.GetAllCode();
            if (listOfCategoryCode != null)
            {
                if (listOfCategoryCode.Count == 999)
                {
                    generatedCode = "Unable to Generate Code";
                }
                foreach(var item in listOfCategoryCode)
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
             status =itemCategoryDal.CheckCategoryName(categoryName);
            return status;
        }

        internal List<ItemCategory> GetParentCategories()
        {
            List<ItemCategory> listOfItemCategory = itemCategoryDal.GetParentCategories();
            return listOfItemCategory;
        }
    }
}