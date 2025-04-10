using IKEA.DAL.Models.DepartmentsModel;
using IKEA.DAL.Models.EmployeeModels;
using IKEA.DAL.Persintance.Data.Contexts;
using IKEA.DAL.Persintance.Reposatories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persintance.Reposatories.classes
{
    public class EmployeeRepository(ApplicationDbcontext dbcontext):GenericRepository<Employee>(dbcontext),IEmployeeRepository
    {
      
    }
}
