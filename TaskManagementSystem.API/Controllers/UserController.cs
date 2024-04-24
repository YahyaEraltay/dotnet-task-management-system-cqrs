using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Users.Commands.Create;
using TaskManagementSystem.Application.Users.Commands.Delete;
using TaskManagementSystem.Application.Users.Commands.Update;
using TaskManagementSystem.Application.Users.Queries.All;
using TaskManagementSystem.Application.Users.Queries.Detail;

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

        [HttpPut("[action]")]
        public async Task<ActionResult> Update(UpdateUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> All()
        {
            var request = new AllUserRequest();
            var result = await _mediator.Send(request);
                
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> Detail(DetailUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
