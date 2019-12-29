using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectManagementApi.Business;
using ProjectManagementApi.Models;
using TaskModel = ProjectManagementApi.Models.Task;

namespace ProjectManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskBlc _taskBlc;
        private readonly ILogger<TaskController> _logger;
        public TaskController(ITaskBlc taskBlc, ILogger<TaskController> logger)
        {
            _taskBlc = taskBlc;
            _logger = logger;
        }
        [HttpPost]
        [Route("AddTask")]
        public string AddTask([FromBody]TaskModel TaskInput)
        {
            try
            {
                _logger.LogInformation("Adding task to database");
                var response = _taskBlc.AddTask(TaskInput);
                if (response != null)
                {
                    return response;

                }
                else
                {
                    _logger.LogInformation("Error in adding task to database");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in service");
                return null;
            }
        }
        [HttpPost]
        [Route("AddParentTask")]
        public string AddParentTask([FromBody]ParentTask TaskInput)
        {
            try
            {
                _logger.LogInformation("Adding task to database");
                var response = _taskBlc.AddParentTask(TaskInput);
                if (response != null)
                {
                    return response;

                }
                else
                {
                    _logger.LogInformation("Error in adding task to database");
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
        [Route("Get")]
        public List<TaskModel> Get()
        {

            try
            {
                _logger.LogInformation("Retrieveing task from database");
                var response = _taskBlc.ViewTask();
                if (response != null)
                {
                    return response;

                }
                else
                {
                    _logger.LogInformation("No tasks in database");
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
        [Route("GetTasks")]
        public List<TaskModel> GetTasks()
        {

            try
            {
                _logger.LogInformation("Retrieveing task from database");
                var response = _taskBlc.GetTasks();
                if (response != null)
                {
                    return response;

                }
                else
                {
                    _logger.LogInformation("No tasks in database");
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
        [Route("View")]
        public List<TaskModel> View([FromQuery]string projects)
        {

            try
            {
                _logger.LogInformation("Retrieveing task from database");
                var response = _taskBlc.View(projects);
                if (response != null)
                {
                    return response;

                }
                else
                {
                    _logger.LogInformation("No tasks in database");
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