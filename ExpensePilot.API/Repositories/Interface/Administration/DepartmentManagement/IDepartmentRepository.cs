using ExpensePilot.API.Models.Domain.Administration.DepartmentManagement;

namespace ExpensePilot.API.Repositories.Interface.Administration.DepartmentManagement
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateAsync (Department department);
        Task <IEnumerable<Department>> GetAllAsync();
        Task<Department> GetByIdAsync (int id);
        Task<Department> UpdateAsync (Department department);
        Task<Department> DeleteAsync (int id);
    }
}
