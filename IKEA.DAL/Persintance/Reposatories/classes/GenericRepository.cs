using IKEA.DAL.Models.EmployeeModels;
using IKEA.DAL.Models.Shared.Classes;
using IKEA.DAL.Persintance.Data.Contexts;
using IKEA.DAL.Persintance.Reposatories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persintance.Reposatories.classes
{
    public class GenericRepository<T>(ApplicationDbcontext _dbcontext) : IGenericRepositories<T> where T : BaseEntity
    {

        //Get All
        public IEnumerable<T> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
                return _dbcontext.Set<T>().Where(E=>E.IsDeleted != true).ToList();
            else
                return _dbcontext.Set<T>().AsNoTracking().ToList();
            //if U Did not want to Track it 
        }

        //GetByID
        public T? GetById(int id) => _dbcontext.Set<T>().Find(id);
        //{
        //    var department = _dbcontext.Departments.Find(id);
        //    return department;
        //}

        //Update
        public int Update(T emp)
        {
            _dbcontext.Set<T>().Update(emp);
            int Result = _dbcontext.SaveChanges();
            return Result;
        }


        //Delete
        public int Remove(T emp)
        {
            _dbcontext.Set<T>().Remove(emp);
            return _dbcontext.SaveChanges();
        }



        //Insert

        public int Add(T emp)
        {
            _dbcontext.Set<T>().Add(emp);
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> Predict)
        {
            return _dbcontext.Set<T>()
                 .Where(Predict)
                 .ToList();
        }
    }
}
