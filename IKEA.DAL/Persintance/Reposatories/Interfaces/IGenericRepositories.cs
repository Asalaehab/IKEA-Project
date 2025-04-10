using IKEA.DAL.Models.EmployeeModels;
using IKEA.DAL.Models.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persintance.Reposatories.Interfaces
{
    public interface IGenericRepositories<T> where T : BaseEntity
    {
        int Add(T department);
        IEnumerable<T> GetAll(bool WithTracking = false);
        T? GetById(int id);
        int Remove(T department);
        int Update(T department);
    }
}
