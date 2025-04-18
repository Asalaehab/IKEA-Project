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
        private Lazy< IEmployeeRepository> _employeeRepository;
        private readonly ApplicationDbcontext _dbcontext;
        private Lazy<IDepartmentRepository> _departmentRepository;
        public UnitOfWork(IDepartmentRepository departmentRepository,IEmployeeRepository employeeRepository,ApplicationDbcontext dbcontext)
        {
            _departmentRepository = new Lazy<IDepartmentRepository>();
            _employeeRepository = new Lazy<IEmployeeRepository>();
            _dbcontext = dbcontext;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

        public int SaveChange()=>  _dbcontext.SaveChanges();
        
    }
}
