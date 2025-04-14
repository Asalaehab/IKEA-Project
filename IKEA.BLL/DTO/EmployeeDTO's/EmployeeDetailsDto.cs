using IKEA.DAL.Models.EmployeeModels;
using IKEA.DAL.Models.Shared.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO.EmployeeDTO_s
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Address { get; set; } = null!;

        public bool IsActive { get; set; }

        public decimal Salary { get; set; }

        public string email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateOnly HiringDate { get; set; }

        public string gender { get; set; }=null!;

        public string EmployeeType { get; set; } = null!;


        public int CreatedBy { get; set; }//User Id


        public int LastModifiedBy { get; set; }//User Id


        public DateOnly CreatedOn { get; set; }

        public DateOnly LastMoifiedOn { get; set; }//User Id

    }
}
