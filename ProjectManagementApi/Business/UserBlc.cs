using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementApi.Models;
using ProjectManagementApi.DataAccess;

namespace ProjectManagementApi.Business
{
    public class UserBlc : IUserBlc
    {
        private readonly IUserDalc _userDalc;
        public UserBlc(IUserDalc userDalc)
        {
            _userDalc = userDalc;
        }
        public string AddUser(UsersTable users)
        {
            return _userDalc.AddUser(users);
        }

        public string DeleteUser(string employeeId)
        {
           return _userDalc.DeleteUser(employeeId);
        }

        public string UpdateUser(string FirstName, string LastName, string EmployeeId, string ProjectId, string TaskId)
        {
           return _userDalc.UpdateUser(FirstName,LastName,EmployeeId,ProjectId,TaskId);
        }

        public List<UsersTable> ViewUser()
        {
            return _userDalc.ViewUser();
        }

    }
}
