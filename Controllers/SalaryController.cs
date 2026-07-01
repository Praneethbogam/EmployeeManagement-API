using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SalaryController : ControllerBase
{
    private readonly ISalaryService _service;

    public SalaryController(ISalaryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _service.GetById(id);
        if (data == null) return NotFound();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Salary salary)
    {
        var result = await _service.Create(salary);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Salary salary)
    {
        await _service.Update(id, salary);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok();
    }

    [HttpGet("employee/{employeeId}")]
    public async Task<IActionResult> GetByEmployee(int employeeId)
    {
        return Ok(await _service.GetByEmployee(employeeId));
    }

    [HttpGet("current/{employeeId}")]
    public async Task<IActionResult> GetCurrent(int employeeId)
    {
        return Ok(await _service.GetCurrentSalary(employeeId));
    }
}