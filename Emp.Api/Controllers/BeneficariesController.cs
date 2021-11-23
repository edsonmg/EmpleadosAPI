using Emp.Business.Interfaces;
using Emp.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Emp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BeneficariesController : ControllerBase
    {
        private readonly IBeneficiaries _ben;

        public BeneficariesController(IBeneficiaries benef)
        {
            _ben = benef;
        }

        [HttpPost]
        public IActionResult addbeneficiary([FromBody] Beneficiaries ben)
        {
            return new JsonResult(_ben.addBeneficiaries(ben));
        }
    }
}
