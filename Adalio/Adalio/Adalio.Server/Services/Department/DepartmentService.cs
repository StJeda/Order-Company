namespace Adalio.Services.Department
{
    using Domain.Models;
    public class DepartmentService : IDepartmentService
    {
        public async Task<List<Department>?> GetAllDepartments()
            => await dbContext.GetAllDepartmentsAsync();

        public async Task<Department?> GetSingleDepartment(Guid id)
        {
            try
            {
                var selDepartment = await dbContext.GetDepartmentByIdAsync(id);
                if (selDepartment is null)
                    throw new ArgumentNullException();
                return Task.FromResult(selDepartment);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public async Task<bool> AddDepartment(Department addDepartment)
        {
            try
            {
                if (addDepartment is null)
                    throw new ArgumentNullException();
                await dbContext.AddDepartmentAsync(addDepartment);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDepartment(Department updateDepartment)
        {
            try
            {
                var selDepartment = await dbContext.GetDepartmentByIdAsync(updateProduct.Id);
                if (selDepartment is null)
                    throw new ArgumentNullException();
                await dbContext.UpdateProductAsync(selDepartment);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
        public async Task<bool> DeleteDepartment(Guid id)
        {
            try
            {
                var selDepartment = await dbContext.GetDepartmentByIdAsync(id);
                if (selDepartment is null)
                    throw new ArgumentNullException();
                await dbCotntext.DeleteDepartmentAsync(selDepartment);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
