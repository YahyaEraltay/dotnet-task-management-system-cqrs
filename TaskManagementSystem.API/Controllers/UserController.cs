using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Users.Commands.Create;
using TaskManagementSystem.Application.Users.Commands.Delete;

namespace Task_Management_System_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Create(CreateUserRequest request)
        {
            var result = await _mediator.Send(request); 
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete(DeleteUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
