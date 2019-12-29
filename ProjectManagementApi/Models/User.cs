using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Models
{
    public class User
    {
            public string UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmployeeId { get; set; }
            public string ProjectId { get; set; }
            public string TaskId { get; set; }
    }

}

