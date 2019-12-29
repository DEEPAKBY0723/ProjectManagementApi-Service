using ProjectManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.DataAccess
{
    public interface IProjectDalc
    {
        List<ProjectDetails> GetProjectDetails();
        List<Projects> GetManagers();
        string AddProject(Projects projectInput);

        List<Projects> GetProjects();
    }
}
