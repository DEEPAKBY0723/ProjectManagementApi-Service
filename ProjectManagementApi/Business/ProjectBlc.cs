using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementApi.DataAccess;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Business
{
    public class ProjectBlc : IProjectBlc
    {
        private readonly IProjectDalc _projectDalc;
        public ProjectBlc(IProjectDalc projectDalc)
        {
            _projectDalc = projectDalc;
        }

        public string AddProject(Projects projectInput)
        {
            projectInput.ProjectId = projectInput.Project + "123";
            return _projectDalc.AddProject(projectInput);
        }

        public List<ProjectDetails> GetProjectDetails()
        {
            return _projectDalc.GetProjectDetails();
        }

        public List<Projects> GetManagers()
        {
            return _projectDalc.GetManagers();
        }

        public List<Projects> GetProjects()
        {
            return _projectDalc.GetProjects();
        }
    }
}
