using System.ComponentModel.DataAnnotations;

namespace IKEA.PL.Views.DepartmentViewModel
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "Name Can't Be Null")]
        [MaxLength(50, ErrorMessage = "Max Length Should be 50 Charcter")]
        [MinLength(5, ErrorMessage = "Min Length shoulld be at least 5")]
        public string Name { get; set; } = string.Empty;

        [Range(22, 50)]
        public int? Age { get; set; }
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

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        public string gender { get; set; } = null!;

        public string EmployeeType { get; set; } = null!;

        public int CreatedBy { get; set; }//User Id

        public int LastModifiedBy { get; set; }//User Id

        [Display(Name="Department Id")]
        public int? DepartmentId { get; set; }
    }
}
