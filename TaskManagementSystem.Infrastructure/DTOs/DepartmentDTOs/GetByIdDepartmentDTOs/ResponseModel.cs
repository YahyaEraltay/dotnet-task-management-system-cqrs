using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.GetByIdDepartmentDTOs
{
    public class ResponseModel
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
