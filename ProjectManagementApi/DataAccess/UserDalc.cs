using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementApi.EfCore;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.DataAccess
{
    public class UserDalc : IUserDalc
    {
        private readonly ReportServerContext _dbContext;
        public  UserDalc(ReportServerContext reportServerContext)
        {
            _dbContext = reportServerContext;
        }
        public string AddUser(UsersTable users)
        {
            _dbContext.UsersTable.Add(users);
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

        public string DeleteUser(string employeeId)
        {
            throw new NotImplementedException();
        }

        public string UpdateUser(string FirstName, string LastName, string EmployeeId, string ProjectId, string TaskId)
        {
           return null;
        }

        public List<UsersTable> ViewUser()
        {
            List<UsersTable> userDetails = (from users in _dbContext.UsersTable
                                            select new UsersTable()
                                            {
                                                EmployeeId = users.EmployeeId,
                                                FirstName=users.FirstName,
                                                LastName=users.LastName,
                                              
                                                    

                                            }).ToList();
            return userDetails;
                                   
        }

      
    }
}
