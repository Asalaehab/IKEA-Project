using IKEA.BLL.DTO.EmployeeDTO_s;
using IKEA.DAL.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAll(bool WithTracking);

        public EmployeeDetailsDto? GetById(int id);

        public int Create(CreatedEmployeeDto createdEmployeeDto);

        public int Update(UpdatedEmployeeDto dto);

        public bool Delete(int id);
    }
}
