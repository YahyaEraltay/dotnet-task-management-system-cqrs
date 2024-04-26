using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.ToDoTasks.Commands.Create;
using TaskManagementSystem.Application.ToDoTasks.Commands.Delete;
using TaskManagementSystem.Application.ToDoTasks.Commands.Update;
using TaskManagementSystem.Application.ToDoTasks.Queries.All;
using TaskManagementSystem.Application.ToDoTasks.Queries.Detail;

namespace Task_Management_System_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Create(CreateToDoTaskRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete(DeleteToDoTaskRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Update(UpdateToDoTaskRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> All()
        {
            var result = await _mediator.Send(new AllToDoTaskRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> Detail(DetailToDoTaskRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
