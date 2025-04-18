using IKEA.DAL.Models.EmployeeModels;
using IKEA.DAL.Models.Shared.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO.EmployeeDTO_s
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
    ErrorMessage = "Address Must Be Like 123-street-city-country")]
        public string? Address { get; set; } = null!;

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [EmailAddress]
        public string email { get; set; } = null!;

        [Phone]
        public string PhoneNumber { get; set; } = null!;
        public string gender { get; set; } = null!;

        public string EmpType { get; set; } = null!;


        public string? Department { get; set; }
    }
}
