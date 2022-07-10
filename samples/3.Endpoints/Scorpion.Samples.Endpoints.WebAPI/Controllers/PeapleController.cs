using Microsoft.AspNetCore.Mvc;
using Scorpion.Endpoints.WebApi.Controllers;
using Scorpion.Samples.Core.Contracts.Peaple.Commands;

namespace Scorpion.Samples.Endpoints.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeapleController : BaseController
    {
        public PeapleController()
        {

        }

        [HttpPost("CreatePerson")]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePerson createPerson)
        {
            return await Create<CreatePerson, long>(createPerson);
        }
    }
}
