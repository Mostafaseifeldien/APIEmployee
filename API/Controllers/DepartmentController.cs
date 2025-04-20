using ContactsManager.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.DataAccess;
using MyWebApi.Models;
using MyWebApi.RepositoryContracts;

namespace API.Controllers
{
    public class DepartmentController : BaseApiController
    {
        private readonly IDepartmentAdderService _departmentAdderService;
        private readonly IDepartmentGetterService _departmentGetterService;
        private readonly IDepartmentDeleterService _departmentDeleterService;
        private readonly IDepartmentUpdaterService _departmentUpdaterService;
        public DepartmentController(IDepartmentAdderService departmentAdderService,
            IDepartmentGetterService departmentGetterService,
            IDepartmentDeleterService departmentDeleterService,
            IDepartmentUpdaterService departmentUpdaterService)
        {
            _departmentAdderService = departmentAdderService;
            _departmentGetterService = departmentGetterService;
            _departmentDeleterService = departmentDeleterService;
            _departmentUpdaterService = departmentUpdaterService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            List<Department> allDepartment = _departmentGetterService.GetAllDepartments().ToList();
            return allDepartment;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            Department? department = await _departmentGetterService.GetDepartmentById(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(string name)
        {
            if (name == null)
            {
                throw new Exception("Enter name");
            }
            Department department = new Department
            {
                Name = name
            };
            Department departmentobj = await _departmentAdderService.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartment), new { id = departmentobj.Id }, departmentobj);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> PutDepartment(int id, string name)
        {
            if (id == 0 || name == null)
            {
                throw new Exception("please enter name or id");
            }
            Department department = await _departmentUpdaterService.UpdateDepartment(id, name);
            return department;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteDepartment(int id)
        {
            await _departmentDeleterService.DeleteDepartment(id);
            return Ok("Deleted");
        }
    }
}
