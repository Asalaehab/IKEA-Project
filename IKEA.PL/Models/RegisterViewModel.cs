using System.ComponentModel.DataAnnotations;

namespace IKEA.PL.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="First Name Can Not Be null")]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;


        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string  Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }

    }
}
