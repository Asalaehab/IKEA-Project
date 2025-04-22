using System.ComponentModel.DataAnnotations;

namespace IKEA.PL.Views.Account
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; } = null!;
    }
}
