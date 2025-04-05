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
        private readonly IDepartmentRepository departmentRepository;

       
        //DepartmentRepository departmentRepository=new DepartmentRepository(new DAL.Persintance.Data.Contexts.ApplicationDbcontext() what will happen if i am not create DI.
        public DepartmentService(IDepartmentRepository departmentRepository)//1-Injection
        {
            this.departmentRepository = departmentRepository;
        }
    }
}
