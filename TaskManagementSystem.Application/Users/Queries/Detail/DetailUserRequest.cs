using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Users.Queries.Detail
{
    public class DetailUserRequest : IRequest<DetailUserResponse>
    {
        public Guid Id { get; set; }
    }
}
