using IKEA.DAL.Models.DepartmentsModel;
using IKEA.DAL.Persintance.Data.Contexts;
using IKEA.DAL.Persintance.Reposatories.classes;
using IKEA.DAL.Persintance.Reposatories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persintance.Reposatories.classes
{

    //Primary Constructor
    public class DepartmentRepository(ApplicationDbcontext dbcontext) : GenericRepository<Department>(dbcontext),IDepartmentRepository
    {
       
    }
}
