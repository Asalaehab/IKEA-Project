using IKEA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO
{
    public class DepartmentDetailsDTO
    {
        ////Constructor Mapping
        //public DepartmentDetailsDTO(Department department)
        //{
        //    Id = department.Id;
        //    Name = department.Name;
        //    Code = department.Code;
        //    Description = department.Description;
        //}



        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int Id { get; set; }//PK

        public int CreatedBy { get; set; }//User Id

        public DateOnly CreatedOn { get; set; }

        public int LastModifiedBy { get; set; }//User Id

        public DateOnly LastMoifiedOn { get; set; } //Date Of Modification

        public bool IsDeleted { get; set; } //Soft Deleted
    }
}
