using IKEA.DAL.Models.DepartmentsModel;
using IKEA.DAL.Models.Shared.Classes;
using IKEA.DAL.Models.Shared.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.EmployeeModels
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Address { get; set; } = null!;

        public bool IsActive { get; set; }

        public decimal Salary { get; set; }

        public string email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime HiringDate { get; set; }

        public Gender gender { get; set; }

        public EmployeeType EmployeeType { get; set; }


        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
