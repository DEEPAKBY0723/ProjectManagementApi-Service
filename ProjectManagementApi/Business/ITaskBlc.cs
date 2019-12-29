using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Business
{
    public interface ITaskBlc
    {
        string AddTask(ProjectManagementApi.Models.Task taskInput);

        List<ProjectManagementApi.Models.Task> ViewTask();
        List<ProjectManagementApi.Models.Task> GetTasks();
        List<ProjectManagementApi.Models.Task> View(string projects);
        string AddParentTask(ProjectManagementApi.Models.ParentTask taskInput);
    }
}
