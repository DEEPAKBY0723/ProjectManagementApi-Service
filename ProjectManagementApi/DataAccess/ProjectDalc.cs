using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementApi.EfCore;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.DataAccess
{
    public class ProjectDalc : IProjectDalc
    {
        private readonly ReportServerContext _dbContext;
        public ProjectDalc(ReportServerContext reportServerContext)
        {
            _dbContext = reportServerContext;
        }
        public List<ProjectDetails> GetProjectDetails()
        {

            //List<ProjectDetails> projectData = (from projects in _dbContext.Projects
            //                              join task in _dbContext.Task
            //                              on projects.ProjectId equals task.ProjectId
            //                              select new ProjectDetails()
            //                              {
            //                                  Project = projects.Project,
            //                                  StartDate = projects.StartDate,
            //                                  EndDate = projects.EndDate,
            //                                  Priority = task.Priority,
            //                                  Completed = task.Status,
            //                                  NoOfTasks =_dbContext.Task.Where(x => x.ProjectId.Equals(projects.ProjectId)).Count().ToString()
            //                                }).ToList();
            List<ProjectDetails> projectData = (from projects in _dbContext.Projects

                                                select new ProjectDetails()
                                                {
                                                    Project = projects.Project,
                                                    StartDate = projects.StartDate,
                                                    EndDate = projects.EndDate,
                                                    Priority = projects.Priority,
                                                    Completed = _dbContext.Task.Where(x => x.ProjectId.Equals(projects.ProjectId)).FirstOrDefault().Status,
                                                    NoOfTasks = _dbContext.Task.Where(x => x.ProjectId.Equals(projects.ProjectId)).Count().ToString()
                                                }).ToList();
            return projectData;
        }
        public List<Projects> GetManagers()
        {
            List<Projects> managers = (from users in _dbContext.UsersTable
                                           select new Projects()
                                           {
                                              Project = users.FirstName + "," + users.LastName,
                                              


                                           }).Distinct().ToList();
          
            return managers;
        }
        public List<Projects> GetProjects()
        {
            List<Projects> projectNames = (from projects in _dbContext.Projects
                                       select new Projects()
                                       {
                                           Project = projects.Project,
                                       }).ToList();
            return projectNames;
        }
        public string AddProject(Projects projectInput)
        {
             _dbContext.Projects.Add(projectInput);
            var addStatus = _dbContext.SaveChanges() > 0;
            if(addStatus)
            {
                return "Success";
            }
            else
            {
                return "Failed to add user details";
            }

        }
    }
}
