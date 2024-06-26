﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagementSystem.Domain.Entites.ToDoTask;

namespace TaskManagementSystem.Application.ToDoTasks.Queries.AssignedToDoTask
{
    public class AssignedToDoTaskResponse
    {
        public  Guid Id { get; set; }
        public DateTime ToDoTaskDate { get; set; }
        public string CreatorUserName { get; set; }
        public string AssignedUserName { get; set; }
        public string AssignedDepartmentName { get; set; }
        public string ToDoTaskName { get; set; }
        public StatusEnum Status { get; set; }
    }
}
