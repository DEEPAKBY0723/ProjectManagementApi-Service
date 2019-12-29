using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.DataAccess
{
    public interface IUserDalc
    {
        string AddUser(UsersTable users);
        List<UsersTable> ViewUser();

        string UpdateUser(string FirstName, string LastName, string EmployeeId, string ProjectId, string TaskId);
        string DeleteUser(string employeeId);
        
        //List<UsersTable> 
        


    }
}
