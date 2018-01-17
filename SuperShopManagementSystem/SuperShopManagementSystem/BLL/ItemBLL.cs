using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;

namespace SuperShopManagementSystem.BLL
{
    public class ItemBLL
    {
        bool status = false;
        ItemDAL itemDal=new ItemDAL();
        internal bool Create(Item item, HttpPostedFileBase ImageFile)
        {
            item.Image = new byte[ImageFile.ContentLength];
            ImageFile.InputStream.Read(item.Image, 0, ImageFile.ContentLength);

            status = itemDal.Create(item);
            return status;
        }



        internal bool Update(Item item)
        {
            status = itemDal.Update(item);
            return status;
        }

        internal bool Delete(int id)
        {
            status = itemDal.Delete(id);
            return status;
        }

        internal Item GetById(int? id)
        {
            Item item = itemDal.GetById(id);
            return item;
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

        internal List<Item> GetAll()
        {
            List<Item> listOfItem = itemDal.GetAll();
            return listOfItem;
        }

        Random randomCode = new Random();
        internal string GetItemCode()
        {
            string generatedCode = "";

            int code1 = randomCode.Next(100, 1000);
            int code2 = randomCode.Next(10000000, 100000000);

            generatedCode ="P"+code1.ToString()+"-"+code2.ToString();

            List<Item> listOfItemCode = itemDal.GetAllCode();
            if (listOfItemCode != null)
            {
                
                foreach (var item in listOfItemCode)
                {
                    if (generatedCode == item.Code)
                    {
                        return GetItemCode();
                    }
                }
            }
            return generatedCode;
        }

        internal bool CheckItemName(string itemName, int itemCategory)
        {
            status = itemDal.CheckItemName(itemName,itemCategory);
            return status;
        }

        internal object GetParentCategories()
        {
            throw new NotImplementedException();
        }
    }
}