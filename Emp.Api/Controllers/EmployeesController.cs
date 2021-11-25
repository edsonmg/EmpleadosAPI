using Emp.Business.Interfaces;
using Emp.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Emp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployee _emp;
     public EmployeesController(IEmployee employee)
        {
            _emp = employee;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee emp)
        {
            var result = await _emp.addEmployee(emp);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> LsEmployees()
        {
                var result = await _emp.lsEmployees();
            return  Ok(result);
        }

        [HttpPut]
        public async Task< IActionResult> updEmployee([FromBody] Employee emp)
        {
            var result = await _emp.updEmployee(emp);
            return Ok(result);
        }

        [HttpDelete]
        public async Task< IActionResult> delEmployee([FromBody] Employee emp)
        {
            var result = await _emp.delEmployee(emp);
            return Ok(result);
        }
    }


}
