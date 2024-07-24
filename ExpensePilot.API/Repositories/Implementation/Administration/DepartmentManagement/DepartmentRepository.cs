using ExpensePilot.API.Data;
using ExpensePilot.API.Models.Domain.Administration.DepartmentManagement;
using ExpensePilot.API.Repositories.Interface.Administration.DepartmentManagement;
using Microsoft.EntityFrameworkCore;

namespace ExpensePilot.API.Repositories.Implementation.Administration.DepartmentManagement
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Department> CreateAsync(Department department)
        {
            await dbContext.tblEPDepartments.AddAsync(department);
            await dbContext.SaveChangesAsync();
            return department;
        }

        public async Task<Department> DeleteAsync(int id)
        {
            var existingDepartment = await dbContext.tblEPDepartments.FirstOrDefaultAsync(d => d.DptID == id);
            if(existingDepartment is null)
            {
                return null;
            }
            dbContext.tblEPDepartments.Remove(existingDepartment);
            await dbContext.SaveChangesAsync();
            return existingDepartment;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await dbContext.tblEPDepartments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await dbContext.tblEPDepartments.FirstOrDefaultAsync(d => d.DptID == id);
        }

        public async Task<Department> UpdateAsync(Department department)
        {
            var existingDepartment = await dbContext.tblEPDepartments.FirstOrDefaultAsync(d => d.DptID == department.DptID);
            if(existingDepartment is null)
            {
                return null;
            }
            dbContext.Entry(existingDepartment).CurrentValues.SetValues(department);
            await dbContext.SaveChangesAsync();
            return department;
        }
    }
}
