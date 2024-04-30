using MediatR;

namespace TaskManagementSystem.Application.ToDoTasks.Commands.Delete
{
    public class DeleteToDoTaskRequest : IRequest<DeleteToDoTaskResponse>
    {
        public Guid Id { get; set; }
        public Guid CreatorUserId { get; set; }
    }
}
