using ProjectManagementApi.EfCore;
using ProjectManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskModel = ProjectManagementApi.Models;

namespace ProjectManagementApi.DataAccess
{
    public class TaskDalc : ITaskDalc
    {
        private readonly ReportServerContext _dbContext;
        public TaskDalc(ReportServerContext reportServerContext)
        {
            _dbContext = reportServerContext;

        }

        public string AddParentTask(ParentTask taskInput)
        {
            _dbContext.ParentTask.Add(taskInput);
            var addStatus = _dbContext.SaveChanges() > 0;
            if (addStatus)
            {
                return "Success";
            }
            else
            {
                return "Failed to add user details";
            }
        }

        public string AddTask(TaskModel.Task taskInput)
        {
            taskInput.ProjectId = _dbContext.Projects.Where(x => x.Project.Equals(taskInput.ProjectId)).FirstOrDefault().ProjectId;

            _dbContext.Task.Add(taskInput);
            var addStatus = _dbContext.SaveChanges() > 0;
            if (addStatus)
            {
                return "Success";
            }
            else
            {
                return "Failed to add user details";
            }

        }

        public List<TaskModel.Task> GetTasks()
        {
            List<TaskModel.Task> taskData = (from task in _dbContext.ParentTask

                                             select new TaskModel.Task()
                                             {
                                                 Task1 = task.ParentTasks
                                             }).Distinct().ToList();
            return taskData;
        }

        public List<TaskModel.Task> View(string projects)
        {
            List<string> projectList = new List<string>();
            projects = projects.Substring(1);
            projectList = projects.Split(',').ToList();
           
            List<TaskModel.Task> taskData = (from project in _dbContext.Projects
                                             join task in _dbContext.Task
                                             on project.ProjectId equals task.ProjectId
                                             where projectList.Contains(project.Project)
                                             select new TaskModel.Task()
                                             {
                                                 Task1 = task.Task1,
                                                 ParentId = task.ParentId,
                                                 StartDate = task.StartDate,
                                                 EndDate = task.EndDate,
                                                 Priority = task.Priority
                                             }).Distinct().ToList();
            return taskData;
        }

        public List<TaskModel.Task> ViewTask()
        {
            List<TaskModel.Task> taskData = (from taskTble in _dbContext.Task
                                           
                                             select new TaskModel.Task()
                                             {
                                                 Task1 = taskTble.Task1,
                                                 ParentId=taskTble.ParentId,
                                                 StartDate=taskTble.StartDate,
                                                 EndDate=taskTble.EndDate,
                                                 Priority=taskTble.Priority
                                          }).Distinct().ToList();
            return taskData;
        }
    }
}
