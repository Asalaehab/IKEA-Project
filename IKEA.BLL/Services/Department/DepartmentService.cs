using IKEA.BLL.DTO;
using IKEA.BLL.Factories;
using IKEA.DAL.Persintance.Reposatories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.Department
{
    public class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
    {
        //private readonly IDepartmentRepository _departmentRepository;


        //DepartmentRepository departmentRepository=new DepartmentRepository(new DAL.Persintance.Data.Contexts.ApplicationDbcontext() what will happen if i am not create DI.
        


        public IEnumerable<DepartmentDto> GetAllDepartents()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();

            var DepartmentsToReturn = departments.Select(D => new DepartmentDto()
            {
                DeptId = D.Id,
                Code = D.Code,
                Name = D.Name,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn)
            });//this what we called Mapping


            return DepartmentsToReturn;
        }



        //Get By Id
        public DepartmentDetailsDTO? GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);

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
             _unitOfWork.DepartmentRepository.Add(department);
            return _unitOfWork.SaveChange();

        }

        //Update
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
             _unitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
            return _unitOfWork.SaveChange();
        }

        //Delete Department

        public bool DeleteDepartment(int id)
        {
            var Dept = _unitOfWork.DepartmentRepository.GetById(id);
            if (Dept is null)
                return false;
            else
            {
                 _unitOfWork.DepartmentRepository.Remove(Dept);

                int Result = _unitOfWork.SaveChange();
                if (Result > 0)
                    return true;
                else
                    return false;
            }
        }

    }
}
