using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO
{
   public class CreatedDepartmentDto
    {
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage ="Code is required")]
        [Range(100,int.MaxValue)]
        public string Code { get; set; } = null!;

        public string? Description { get; set; } = string.Empty;

        public DateOnly DateOfCreation { get; set; }
    }
}
