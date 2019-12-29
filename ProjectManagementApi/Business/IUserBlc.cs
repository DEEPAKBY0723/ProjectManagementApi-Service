using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Business
{
   public interface IUserBlc
    {
        string AddUser(UsersTable users);

        List<UsersTable> ViewUser();

        string UpdateUser(string FirstName, string LastName, string EmployeeId, string ProjectId, string TaskId);

        string DeleteUser(string employeeId);
    }
}
