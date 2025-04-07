using IKEA.DAL.Persintance.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persintance.Reposatories
{

    //Primary Constructor
    public class DepartmentRepository(ApplicationDbcontext dbcontext) : IDepartmentRepository
    {
        private readonly ApplicationDbcontext _dbcontext = dbcontext;

        //CRUD
        //Get All
        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbcontext.Departments.ToList();
            else
                return _dbcontext.Departments.AsNoTracking().ToList();
            //if U Did not want to Track it 
        }

        //GetByID
        public Department? GetById(int id) => _dbcontext.Departments.Find(id);
        //{
        //    var department = _dbcontext.Departments.Find(id);
        //    return department;
        //}

        //Update
        public int Update(Department department)
        {
            _dbcontext.Departments.Update(department);
            int Result = _dbcontext.SaveChanges();
            return Result;
        }


        //Delete
        public int Remove(Department department)
        {
            _dbcontext.Departments.Remove(department);
            return _dbcontext.SaveChanges();
        }



        //Insert

        public int Add(Department department)
        {
            _dbcontext.Departments.Add(department);
            return _dbcontext.SaveChanges();
        }
    }
}
