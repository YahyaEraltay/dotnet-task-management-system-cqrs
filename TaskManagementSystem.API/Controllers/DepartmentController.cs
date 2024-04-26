using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Departments.Commands.Create;
using TaskManagementSystem.Application.Departments.Commands.Delete;
using TaskManagementSystem.Application.Departments.Commands.Update;
using TaskManagementSystem.Application.Departments.Queries.All;
using TaskManagementSystem.Application.Departments.Queries.Detail;

namespace Task_Management_System_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Create(CreateDepartmentRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Update(UpdateDepartmentRequest request)
        {
            var result = await _mediator.Send(request); 
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete(DeleteDepartmentRequest request)
        {
            var result = await _mediator.Send(request); 
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> Detail(DetailDepartmentRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> All()
        {
            var result = await _mediator.Send(new AllDepartmentRequest());
            return Ok(result);
        }
    }
}
