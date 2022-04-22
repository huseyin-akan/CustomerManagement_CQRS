using Application.Features.CourtCases.Commands.CreateCourtCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CourtCaseController : BaseController
    {   
        [Authorize(Roles = "add-courtcase")]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCourtCaseCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
