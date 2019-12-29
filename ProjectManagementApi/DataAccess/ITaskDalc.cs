using ProjectManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.DataAccess
{
   public interface ITaskDalc
    {
        string AddTask(ProjectManagementApi.Models.Task taskInput);

        string AddParentTask(ParentTask taskInput);
        List<ProjectManagementApi.Models.Task> ViewTask();
        List<ProjectManagementApi.Models.Task> GetTasks();

        List<ProjectManagementApi.Models.Task> View(string projects);
    }
}
