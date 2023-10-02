using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFai.Models;
using System.Security.Policy;

namespace ProjectFai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmpDbContext context;
        public EmployeeController(EmpDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> AllEmployees()
        {
            return await context.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> FindEmployee(int id)
        {
            return await context.Employees.FindAsync(id) ?? throw new Exception("Emp not found");
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(FindEmployee), new { id = employee.eId }, employee);
        }
        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateExample(int id, Employee example)
        {
            Employee ex = context.Employees.Find(id) ?? throw new Exception("Emp not found");
            ex.EmpName = example.EmpName;
            ex.EmpRole = example.EmpRole;
            ex.EmpEmailAddress = example.EmpEmailAddress;
            ex.EmpPhoneNumber = example.EmpPhoneNumber;
            ex.EmpPassword = example.EmpPassword;
            await context.SaveChangesAsync();
            return await context.Employees.ToListAsync();
        }
        public async Task<ActionResult<List<Employee>>> DeleteExample(int id)
        {
            Employee ex = context.Employees.Find(id) ?? throw new Exception("Emp not found");
            context.Employees.Remove(ex);
            await context.SaveChangesAsync();
            return await context.Employees.ToListAsync();
        }

    }
}

       