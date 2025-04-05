using IKEA.DAL.Persintance.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persintance.Reposatories
{

    //Primary Constructor
    public class DepartmentRepository(ApplicationDbcontext dbcontext)
    {
        private readonly ApplicationDbcontext _dbcontext = dbcontext;

        //CRUD

        //Get All

        //GetByID
        public Department? GetById(int id)
        {
            var department = _dbcontext.Departments.Find(id);
            return department;
        }


        //Insert

        //Update


        //Delete
    }
}
