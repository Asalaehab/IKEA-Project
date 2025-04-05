
namespace IKEA.DAL.Persintance.Reposatories
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