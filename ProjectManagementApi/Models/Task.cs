using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementApi.Models
{
    public partial class Task
    {
        public string ParentId { get; set; }
        public string ProjectId { get; set; }
        public string Task1 { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
     

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
    }
}
