using AutoMapper;
using IKEA.BLL.DTO.EmployeeDTO_s;
using IKEA.BLL.Factories;
using IKEA.DAL.Models.EmployeeModels;
using IKEA.DAL.Persintance.Reposatories.classes;
using IKEA.DAL.Persintance.Reposatories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IKEA.BLL.Services.EmployeeServices
{
    public class EmployeeService(IMapper _mapper,IUnitOfWork _unitOfWork) : IEmployeeService
    {
        //private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        

        public IEnumerable<EmployeeDto> GetAll(string? EmployeeSearchName)
        {
      

            ////Src        =>Dest
            ////Employee  => EmployeeDto
            
            IEnumerable<Employee> employees;
            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
            {
                employees = _unitOfWork.EmployeeRepository.GetAll();
            }
            else
            {  
                employees = _unitOfWork.EmployeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName));
            }
            var employeeDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeeDto;

        }



        public EmployeeDetailsDto? GetById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null) { return null; }
           return _mapper.Map<Employee,EmployeeDetailsDto>(employee);
        }


        public int Create(CreatedEmployeeDto createdEmployeeDto)
        {

            var emp = _mapper.Map<CreatedEmployeeDto, Employee>(createdEmployeeDto);
             _unitOfWork.EmployeeRepository.Add(emp);
           return _unitOfWork.SaveChange();
        }

      

      

        public int Update(UpdatedEmployeeDto dto)
        {
             _unitOfWork.EmployeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(dto));
            return _unitOfWork.SaveChange();
        }

        public bool Delete(int id)
        {
            var employee=_unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null) { return false; }
            else
            {
                employee.IsDeleted = true;
                _unitOfWork.EmployeeRepository.Update(employee);
                return _unitOfWork.SaveChange() > 0 ? true : false;
            }
        }

        public IEnumerable<EmployeeDto> GetAll(bool WithTracking = false)
        {
            throw new NotImplementedException();
        }
    }
}
