using IKEA.DAL.Persintance.Data.Contexts;
using IKEA.DAL.Persintance.Reposatories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persintance.Reposatories.classes
{

    public class UnitOfWork : IUnitOfWork
    {
        private IEmployeeRepository _employeeRepository;
        private readonly ApplicationDbcontext _dbcontext;
        private IDepartmentRepository _departmentRepository;
        public UnitOfWork(IDepartmentRepository departmentRepository,IEmployeeRepository employeeRepository,ApplicationDbcontext dbcontext)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _dbcontext = dbcontext;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository;

        public IDepartmentRepository DepartmentRepository => _departmentRepository;

        public int SaveChange()=>  _dbcontext.SaveChanges();
        
    }
}
