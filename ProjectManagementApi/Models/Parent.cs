using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Models
{
    public class ParentTask
    {
        public string ParentTasks { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParentId { get; set; }
    }
}
