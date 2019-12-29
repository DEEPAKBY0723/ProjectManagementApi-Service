using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Models
{
    public class Projects
    {
        public string ProjectId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string Project { get; set; }
        public int Priority { get; set; }



 
    }
}
