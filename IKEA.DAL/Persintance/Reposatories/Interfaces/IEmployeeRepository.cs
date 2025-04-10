using IKEA.DAL.Models.DepartmentsModel;
using IKEA.DAL.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persintance.Reposatories.Interfaces
{
    public interface IEmployeeRepository:IGenericRepositories<Employee>
    {
    }
}
