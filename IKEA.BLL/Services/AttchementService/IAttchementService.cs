using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.AttchementService
{
    public interface IAttchementService
    {
        //Upload
        public string? Upload(IFormFile formFile,string FolderName);
        //Delete
        bool Delete(string filePath); 
    }
}
