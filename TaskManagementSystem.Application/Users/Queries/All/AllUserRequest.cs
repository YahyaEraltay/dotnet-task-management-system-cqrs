using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Users.Queries.All
{
    public class AllUserRequest : IRequest<List<AllUserResponse>>
    {
    }
}
