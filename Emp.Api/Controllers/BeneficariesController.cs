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
    public class BeneficariesController : ControllerBase
    {
        private readonly IBeneficiaries _ben;

        public BeneficariesController(IBeneficiaries benef)
        {
            _ben = benef;
        }

        [HttpPost]
        public async Task<IActionResult> addbeneficiary([FromBody] Beneficiaries ben)
        {
            var result = await _ben.addBeneficiaries(ben);
            return  Ok(result);
        }
    }
}
