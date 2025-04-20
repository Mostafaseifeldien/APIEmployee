using System;
using ContactsManager.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.DataAccess;
using MyWebApi.Models;
using MyWebApi.RepositoryContracts;

namespace API.Controllers
{
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeAdderService _employeeAdderService;
        private readonly IEmployeeGetterService _employeeGetterService;
        private readonly IEmployeeUpdaterService _employeeUpdaterService;
        private readonly IEmployeeDeleterService _employeeDeleterService;
        public EmployeesController(
            IEmployeeAdderService employeeAdderService,
            IEmployeeGetterService employeeGetterService,
            IEmployeeUpdaterService employeeUpdaterService,
            IEmployeeDeleterService employeeDeleterService,
            IDepartmentGetterService departmentGetter)
        {
            _employeeAdderService = employeeAdderService;
            _employeeGetterService = employeeGetterService;
            _employeeUpdaterService = employeeUpdaterService;
            _employeeDeleterService = employeeDeleterService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            List<Employee> allEmployees = _employeeGetterService.GetAllEmployee().ToList();
            return allEmployees;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            Employee? employee = await _employeeGetterService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(string name , int departmentid)
        {
                if(name == null || departmentid == 0)
                {
                    throw new Exception("Please check the name or department id");
                }
                Employee employeeAdd = new Employee()
                {
                    Name = name,
                    DepartmentId = departmentid
                };
                Employee employee = await _employeeAdderService.AddEmployee(employeeAdd);
                return employee;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> PutEmployee(int id, string name, int departmentid)
        {
            if (name == null || departmentid == 0)
            {
                throw new Exception("Please check the name or department id");
            }
            Employee employee = await _employeeUpdaterService.UpdateEmployee(id, name, departmentid);
            return employee;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteEmployee(int id)
        {
            await _employeeDeleterService.DeleteEmployee(id);
            return Ok("Deleted");
        }
    }
}

