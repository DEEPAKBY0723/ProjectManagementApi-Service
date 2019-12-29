using ProjectManagementApi.DataAccess;
using ProjectManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Business
{
    public class TaskBlc : ITaskBlc
    {
        private readonly ITaskDalc _taskDalc;
        public TaskBlc(ITaskDalc projectDalc)
        {
            _taskDalc = projectDalc;
        }

        public string AddParentTask(ParentTask taskInput)
        {
            return _taskDalc.AddParentTask(taskInput);
        }

        public string AddTask(ProjectManagementApi.Models.Task taskInput)
        {
            return _taskDalc.AddTask(taskInput);
        }

        public List<Models.Task> GetTasks()
        {
            return _taskDalc.GetTasks();
        }

        public List<Models.Task> View(string projects)
        {
            return _taskDalc.View(projects);
        }

        public List<ProjectManagementApi.Models.Task> ViewTask()
        {
            return _taskDalc.ViewTask();
        }
    }
}
