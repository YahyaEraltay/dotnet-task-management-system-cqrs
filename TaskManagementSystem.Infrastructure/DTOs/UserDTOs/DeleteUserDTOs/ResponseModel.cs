﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.DTOs.UserDTOs.DeleteUserDTOs
{
    public class ResponseModel
    {
        public bool IsDeleted { get; set; }
        public string Message { get; set; }
    }
}