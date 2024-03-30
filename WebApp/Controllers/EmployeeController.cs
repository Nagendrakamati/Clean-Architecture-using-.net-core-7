using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using WebApp.Application.Services;
using WebApp.Domain.Entities;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController( IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await employeeService.GetAllAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await employeeService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employees employees)
        {
            var createdEmployees = await employeeService.CreateAsync(employees);
            return CreatedAtAction(nameof(GetById), new { id = createdEmployees.ID }, createdEmployees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employees employees)
        {
            int existingEmployees = await employeeService.UpdateAsync(id, employees);
            if (existingEmployees == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int blog = await employeeService.DeleteAsync(id);
            if (blog == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
