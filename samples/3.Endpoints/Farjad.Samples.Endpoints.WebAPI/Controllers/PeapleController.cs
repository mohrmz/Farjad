using Microsoft.AspNetCore.Mvc;
using Farjad.Endpoints.WebApi.Controllers;
using Farjad.Samples.Core.Contracts.Peaple.Commands;

namespace Farjad.Samples.Endpoints.WebAPI.Controllers
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
