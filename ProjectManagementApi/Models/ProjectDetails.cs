using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Models
{
    public class ProjectDetails
    {
        public string ProjectId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string Project { get; set; }
        public int Priority { get; set; }

        public string Completed { get; set; }

        public string NoOfTasks { get; set; }

    }
}
