namespace Adalio.Services.Department
{
    using Domain.Models;
    public interface IDepartmentService
    {
        public Task<List<Department>> GetAllDepartments();
        public Task<Department> GetSingleDepartment(Guid id);
        public Task<bool> AddDepartment(Department addDepartment);
        public Task<bool> DeleteDepartment(Guid id);
        public Task<bool> UpdateDepartment(Department updateDepartment);
    }
}
