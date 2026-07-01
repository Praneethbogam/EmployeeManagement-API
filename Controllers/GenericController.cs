//using Microsoft.AspNetCore.Mvc;
//using TestEmployeeManagement.Data;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//[ApiController]
//[Route("api/[controller]")]
//public class EmployeeController : ControllerBase
//{
//    public readonly IGenericService<Employee> _service;

//    public EmployeeController(IGenericService<Employee> service)
//    {
//        _service = service;
//    }

//    [HttpGet]
//    public async Task<IActionResult> GetAll()
//    {
//        try
//        {
//            var data = await _service.GetAll();
//            return Ok(data);
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, $"Internal Server Error: {ex.Message}");
//        }
//    }

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetById(int id)
//    {
//        try
//        {
//            var emp = await _service.GetById(id);

//            if (emp == null)
//                return NotFound("Employee not found");

//            return Ok(emp);
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, ex.Message);
//        }
//    }

//    [HttpPost]
//    public async Task<IActionResult> Create(Employee employee)   
//    {
//        try
//        {
//            var result = await _service.Create(employee);
//            return Ok(result);
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, ex.Message);
//        }
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> Update(int id,Employee employee)
//    {
//        try
//        {
//            var updated = await _service.Update(id, employee);

//            if (!updated)
//                return NotFound("Employee not found");

//            return Ok("Employee updated successfully");
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, ex.Message);
//        }
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> Delete(int id)
//    {
//        try
//        {
//            var deleted = await _service.Delete(id);

//            if (!deleted)
//                return NotFound("Employee not found");

//            return Ok("Employee deleted successfully");
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, ex.Message);
//        }
//    }
//}
