using Adalio.Domain.Models;
using Adalio.Services.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adalio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController (IDepartmentService service): ControllerBase
    {
        private readonly IDepartmentService _service = service;

        [HttpGet]
        public async Task<IEnumerable<Department>?> GetAll()
            => await _service.GetAllDepartments();

        [HttpGet("{Guid}")]
        public async Task<ActionResult<Department?>> Get(Guid guid)
            => Ok(await _service.GetSingleDepartment(guid));

        [HttpPost]
        public async Task<bool> Add(Department department)
            => await _service.AddDepartment(department);

        [HttpPut]
        public async Task<bool> Update(Department department)
            => await _service.UpdateDepartment(department);

        [HttpDelete]
        public async Task<bool> Delete(Guid guid)
            => await _service.DeleteDepartment(guid);
    }
}
