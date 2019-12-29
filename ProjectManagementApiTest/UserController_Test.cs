using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using ProjectManagementApi;
using ProjectManagementApi.Business;
using ProjectManagementApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjectManagementApiTest
{
    public class UserController_Test
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserController_Test()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async void ViewUser_Test()
        {
            //Arrange
                HttpResponseMessage actualResponse = null;
                string actualResponseContent = string.Empty;
                List<UsersTable> actualListOfTasks = new List<UsersTable>();
            //Act
                using (actualResponse = await _client.GetAsync("api/User/ViewUser"))
                {
                    actualResponseContent = await actualResponse.Content.ReadAsStringAsync();
                    actualListOfTasks = JsonConvert.DeserializeObject<List<UsersTable>>(actualResponseContent);
                }
           //Assert
                Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
                Assert.NotEmpty(actualListOfTasks);
            
        }
        [Fact]
        public async void GetUsers_Test()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            List<UsersTable> actualListOfTasks = new List<UsersTable>();
            //Act
            using (actualResponse = await _client.GetAsync("api/User/GetUsers"))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();
                actualListOfTasks = JsonConvert.DeserializeObject<List<UsersTable>>(actualResponseContent);
            }
            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.NotEmpty(actualListOfTasks);

        }
        [Fact]
        public async void AddUser_Test()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            UsersTable input = new UsersTable();
            input.FirstName = "Nikil";
            input.LastName = "Bhat";
            input.EmployeeId = "9098089";
            string serializedInput = JsonConvert.SerializeObject(input);
            StringContent request = new StringContent(serializedInput, Encoding.UTF8, "application/json");

            //Act
            using (actualResponse = await _client.PostAsync("api/User/AddUser", request))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();
               
            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.Equal("Success",actualResponseContent);

        }
        [Fact]
        public async void AddUser_Test_For_Already_Existing_EmployeeId()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            UsersTable input = new UsersTable();
            input.FirstName = "Nikil";
            input.LastName = "Bhat";
            input.EmployeeId = "9098089";
            input.UserId = 1;
            string serializedInput = JsonConvert.SerializeObject(input);
            StringContent request = new StringContent(serializedInput, Encoding.UTF8, "application/json");
            
            //Act
            using (actualResponse = await _client.PostAsync("api/User/AddUser", request))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();

            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.NotEqual("Success",actualResponseContent);

        }
    }
}
