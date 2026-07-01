using Microsoft.AspNetCore.Mvc;
using TestEmployeeManagement.DTO;

[Route("api/department")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IGenericService<Departments> _service;

    public DepartmentsController(IGenericService<Departments> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(Departments departments)
    {
        try
        {
            var created = await _service.CreateAsync(departments);
            return Ok(created);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, Departments departments)
    {

        var updated = await _service.UpdateAsync(id,departments);

        if (!updated)
            return NotFound($"Department with ID {departments.DepartmentId} not found");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
