using IKEA.BLL.DTO;
using IKEA.BLL.Factories;
using IKEA.DAL.Persintance.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

       
        //DepartmentRepository departmentRepository=new DepartmentRepository(new DAL.Persintance.Data.Contexts.ApplicationDbcontext() what will happen if i am not create DI.
        public DepartmentService(IDepartmentRepository departmentRepository)//1-Injection
        {
            _departmentRepository = departmentRepository;
        }


        public IEnumerable<DepartmentDto> GetAllDepartents()
        {
            var departments = _departmentRepository.GetAll();

            var DepartmentsToReturn = departments.Select(D => new DepartmentDto()
            {
                DeptId=D.Id,
                Code=D.Code,
                Name=D.Name,
                Description=D.Description,
                DateOfCreation=DateOnly.FromDateTime(D.CreatedOn)
            });//this what we called Mapping


            return DepartmentsToReturn;
        }



        //Get By Id
        public DepartmentDetailsDTO? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);

            //if (department is null)
            //    return null;
            //else
            //{
            //    var deparementToReturn = new DepartmentDetailsDTO()
            //    {
            //        Id=department.Id,
            //        Name=department.Name,
            //        Code=department.Code,
            //        Description=department.Description,
            //        CreatedOn=DateOnly.FromDateTime(department.CreatedOn),
            //        LastMoifiedOn=DateOnly.FromDateTime(department.LastMoifiedOn),
            //        CreatedBy=department.CreatedBy,
            //        LastModifiedBy=department.LastModifiedBy
            //    };

            //}

            //Manual Mapping  => Done
            //Auto  Mapper
            //Constructor Mapping
            //Extension Methods

            //return department is null ? null : new DepartmentDetailsDTO()
            //{
            //    Id = department.Id,
            //    Name = department.Name,
            //    Code = department.Code,
            //    Description = department.Description,
            //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
            //    LastMoifiedOn = DateOnly.FromDateTime(department.LastMoifiedOn),
            //    CreatedBy = department.CreatedBy,
            //    LastModifiedBy = department.LastModifiedBy
            //};

            return department is null ? null : department.ToDepartmentDetailsDto(); 
        }



        //Create New Department

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return _departmentRepository.Add(department);

        }

        //Update
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
           return _departmentRepository.Update(departmentDto.ToEntity());
        }

        //Delete Department

        public bool DeleteDepartment(int id)
        {
            var Dept = _departmentRepository.GetById(id);
            if (Dept is null)
                return false;
            else
            {
              int Result= _departmentRepository.Remove(Dept);

                if (Result > 0)
                    return true;
                else
                    return false;
            }
        }

    }
}
