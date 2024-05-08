using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Users.Commands.Create;
using TaskManagementSystem.Application.Users.Commands.Delete;
using TaskManagementSystem.Application.Users.Commands.Login;
using TaskManagementSystem.Application.Users.Commands.Update;
using TaskManagementSystem.Application.Users.Queries.All;
using TaskManagementSystem.Application.Users.Queries.Detail;
using TaskManagementSystem.Infrastructure.Services;

namespace Task_Management_System_CQRS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenerateJwtToken _generateJwtToken;
        private readonly ICurrentUserService _currentUser;

        public UserController(IMediator mediator, IGenerateJwtToken generateJwtToken, ICurrentUserService currentUser)
        {
            _mediator = mediator;
            _generateJwtToken = generateJwtToken;
            _currentUser = currentUser;
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
            var result = await _mediator.Send(new AllUserRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> Detail(DetailUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult> Login(LoginUserRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return Unauthorized(new { message = "Invalid email" });
            }

            var token = _generateJwtToken.GenerateToken(result);

            return Ok(new { token });
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<TaskManagementSystem.Infrastructure.DTOs.UserDTOs.CurrentUserDTOs.ResponseModel>> GetCurrentUser()
        {
            var currentUser = await _currentUser.GetCurrentUser();

            return Ok(currentUser);
        }


    }
}
