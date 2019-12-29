using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectManagementApi.Business;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectBlc _projectBlc;
        private readonly ILogger<ProjectController> _logger;
        public ProjectController(IProjectBlc projectBlc, ILogger<ProjectController> logger)
        {
            _projectBlc = projectBlc;
            _logger = logger;
        }
        [HttpGet()]
        [Route("Get")]
        public List<ProjectDetails> Get()
        {

            try
            {
                _logger.LogInformation("Retriveing project details from database");
                var response = _projectBlc.GetProjectDetails();
                if (response != null)
                {
                    return response;
                }
                else
                {
                    _logger.LogInformation("Np project details from database");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in service");
                return null;
            }



        }

       
        [HttpGet()]
        [Route("GetManagers")]
        public List<Projects> GetManagers()
        {
            try
            {
                _logger.LogInformation("Retriveing managers details from database");
                var response = _projectBlc.GetManagers();
                if (response != null)
                {
                    return response;

                }
                else
                {
                    _logger.LogInformation("No project details retrieved from database");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in service");
                return null;
            }

        }
        [HttpPost()]
        [Route("AddProject")]
        public string AddProject([FromBody]Projects projectInput)
        {
            try
            {
                _logger.LogInformation("Adding project details to database");

                var response = _projectBlc.AddProject(projectInput);
                if (response != null)
                {
                    return response;

                }
                else
                {
                    _logger.LogInformation("Error in adding project details to database");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in service");
                return null;
            }
        }
        [HttpGet()]
        [Route("GetProjects")]
        public List<Projects> GetProjects()
        {
            try
            {
                _logger.LogInformation("Retriveing project details from database");
                var response = _projectBlc.GetProjects();
                if (response != null)
                {
                    return response;

                }
                else
                {
                    _logger.LogInformation("No project details retrieved from database");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in service");
                return null;
            }

        }
    }
}