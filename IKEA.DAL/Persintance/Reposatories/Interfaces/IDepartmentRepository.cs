using IKEA.DAL.Models.DepartmentsModel;

namespace IKEA.DAL.Persintance.Reposatories.Interfaces
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        IEnumerable<Department> GetAll(bool WithTracking = false);
        Department? GetById(int id);
        int Remove(Department department);
        int Update(Department department);
    }
}