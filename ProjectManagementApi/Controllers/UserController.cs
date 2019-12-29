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
    public class UserController : ControllerBase
    {
        private readonly IUserBlc _userBlc;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserBlc userBlc, ILogger<UserController> logger )
        {
            _userBlc = userBlc;
            _logger = logger;
        }
        [HttpPost()]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody]UsersTable users)
        {
            try
            {

                if (users != null)
                {
                    _logger.LogInformation("Adding users to database");
                    var response = _userBlc.AddUser(users);
                    if (response != null)
                    {
                       
                        return Ok(response);

                    }
                    else
                    {
                        _logger.LogInformation("Failed to add users to database");
                        return NotFound();
                    }
                }
                else
                {
                    _logger.LogInformation("Input parmeters are missing");
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in service");
                return Ok(ex.Message);
            }

        }
        
       
        [HttpGet()]
        [Route("ViewUser")]
        public List<UsersTable> ViewUser()
        {
            try
            {
                _logger.LogInformation("view users present in database");
                var response = _userBlc.ViewUser();
                    if (response != null)
                    {
                 
                    return response;

                    }
                else
                {
                    _logger.LogInformation("No users present in database");
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
        [Route("GetUsers")]
        public List<UsersTable> GetUsers()
        {
            try
            {
                _logger.LogInformation("get users present in database");
                var response = _userBlc.ViewUser();
                if (response != null)
                {
                
                    return response;

                }
                else
                {
                    _logger.LogInformation("No users present in database");
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