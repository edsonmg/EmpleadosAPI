using Emp.Business.Interfaces;
using Emp.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddEmployee([FromBody] Employee emp)
        {
            return new JsonResult(_emp.addEmployee(emp));
        }

        [HttpGet]
        public IActionResult LsEmployees()
        {
            
            return new JsonResult(_emp.lsEmployees());
        }

        [HttpPut]
        public IActionResult updEmployee([FromBody] Employee emp)
        {     
            return new JsonResult(_emp.updEmployee(emp));
        }

        [HttpDelete]
        public IActionResult delEmployee([FromBody] Employee emp)
        {
            return new JsonResult(_emp.delEmployee(emp));
        }
    }


}
