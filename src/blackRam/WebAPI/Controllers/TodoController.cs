using Application.Features.Todos.Commands.CreateTodoCommand;
using Application.Features.Todos.Commands.UpdateTodoCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : BaseController
    {
        [Authorize(Roles = "admin, moderator")]
        [HttpPost("add")]
        public async Task<IActionResult> AddTodo([FromBody] CreateTodoCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [Authorize(Roles = "admin, moderator")]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
