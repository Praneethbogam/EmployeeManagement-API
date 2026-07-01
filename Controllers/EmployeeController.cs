
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestEmployeeManagement.DTO;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/employee")]
    [AllowAnonymous]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericService<Employee> _employeeService;
        //public IActionResult GetAction()
        //{
        //    return Ok("api is runing");

        //}
        public EmployeeController(IGenericService<Employee> employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetByIdAsync(id);

                if (employee == null)
                    return NotFound($"Employee with ID {id} not found");

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("bycode/{code}")]
        public async Task<IActionResult> GetEmployeeByCode(string code)
        {
            try
            {
                var employee = await _employeeService.GetByEmployeeCodeAsync(code);

                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdEmployee = await _employeeService.CreateAsync(employee);
                return Ok(createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var updated = await _employeeService.UpdateAsync(id,employee);

                if (!updated)
                    return NotFound($"Employee with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var deleted = await _employeeService.DeleteAsync(id);

                if (!deleted)
                    return NotFound($"Employee with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
