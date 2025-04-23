using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.AttchementService
{
    public class AttchementService : IAttchementService
    {
        List<string> allowedExtension = new List<string>() { ".png", ".jpg", ".Jpeg" };
        int maxSize = 2097152;
        public string? Upload(IFormFile file, string FolderName)
        {
            //1.Check Extensions
            var extension = Path.GetExtension(file.FileName);//split the extension from file name 
            if (!allowedExtension.Contains(extension))
                return null;


            //2.check  Size
            if (file.Length == 0 || file.Length > maxSize)
            {
                return null;
            }

            //3.Get Located Folder Path
            var Folderpath= Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", FolderName);

            //4.Make Attachement Name Unique 
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            //5.Get File Path
            //we will make combine between folderpath and file path to get the file path

            var filePath=Path.Combine(Folderpath,fileName);

            //6.Create File Stream  To Copy File
           
           using FileStream fs = new FileStream(filePath,FileMode.Create);
            

            //7.
            file.CopyTo(fs);

            //8.

            return fileName;



        }

        public bool Delete(string filePath)
        {
            if(!File.Exists(filePath)) return false;
            else
            {
                File.Delete(filePath);
                return true;
            }
        }

    }
}
