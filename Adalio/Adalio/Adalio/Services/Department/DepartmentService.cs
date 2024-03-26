namespace Adalio.Services.Department
{
    using Adalio.Data;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class DepartmentService(DataContext context) : IDepartmentService
    {
        private readonly DataContext _context = context;
        public async Task<List<Department>?> GetAllDepartments()
            => await _context.Departments.ToListAsync();

        public async Task<Department?> GetSingleDepartment(int id)
        {
            try
            {
                var selDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
                if (selDepartment is null)
                    throw new ArgumentNullException();
                return selDepartment;
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
                await _context.AddAsync(addDepartment);
                await _context.SaveChangesAsync();
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
                var selDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Id == updateDepartment.Id);
                if (selDepartment is null)
                    throw new ArgumentNullException();
                selDepartment.Adress = updateDepartment.Adress;
                selDepartment.OrderLines = updateDepartment.OrderLines;
                selDepartment.Importers = updateDepartment.Importers;
                selDepartment.Name = updateDepartment.Name;
                selDepartment.EmployeesNum = updateDepartment.EmployeesNum;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
        public async Task<bool> DeleteDepartment(int id)
        {
            try
            {
                var selDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
                if (selDepartment is null)
                    throw new ArgumentNullException();
                _context.Remove(selDepartment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
