using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Common
    {
        bool status = false;

        //Check Image Format
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


        //Convert Image to Binary
        internal byte[] ConvertImage(HttpPostedFileBase ImageFile)
        {
            byte[] convertedImage = new byte[ImageFile.ContentLength];
            ImageFile.InputStream.Read(convertedImage, 0, ImageFile.ContentLength);
            return convertedImage;
        }
    }
}