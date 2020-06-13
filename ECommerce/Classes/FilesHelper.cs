using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ECommerce.Classes
{
    public class FilesHelper
    {
        public static string UploadPhoto(HttpPostedFileBase file, string folder, string nombre)
        {
            if (file == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(nombre))
            {
                return string.Empty;
            }

            try
            {
                string path = string.Empty;
                string pic = string.Empty;
                string ext = string.Empty;

                if (file != null)
                {
                    ext = Path.GetExtension(file.FileName);
                    pic = string.Format("{0}{1}", nombre, ext);
                    path = Path.Combine(HttpContext.Current.Server.MapPath(folder), string.Format("{0}{1}", nombre, ext));
                    file.SaveAs(path);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                }

                return pic;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}