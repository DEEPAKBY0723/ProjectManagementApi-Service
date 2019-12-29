using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using ProjectManagementApi;
using ProjectManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using TaskModel = ProjectManagementApi.Models.Task;

namespace ProjectManagementApiTest
{
    public class TaskController_Test
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public TaskController_Test()
        {

            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async void Get_Method_Test()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            List<TaskModel> actualListOfTasks = new List<TaskModel>();
            //Act
            using (actualResponse = await _client.GetAsync("api/Task/Get"))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();
                actualListOfTasks = JsonConvert.DeserializeObject<List<TaskModel>>(actualResponseContent);
            }
            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.NotEmpty(actualListOfTasks);

        }
        [Fact]
        public async void GetTasks_Method_Test()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            List<TaskModel> actualListOfTasks = new List<TaskModel>();
            //Act
            using (actualResponse = await _client.GetAsync("api/Task/GetTasks"))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();
                actualListOfTasks = JsonConvert.DeserializeObject<List<TaskModel>>(actualResponseContent);
            }
            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.NotEmpty(actualListOfTasks);

        }
        [Fact]
        public async void AddTask_Test_For_Project()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            TaskModel input = new TaskModel();
            input.Task1 = "Update UTC document";
            input.StartDate = Convert.ToDateTime("12/10/2019");
            input.EndDate = Convert.ToDateTime("12/10/2020");
            input.Priority = 1;
            input.ProjectId = "MIS123";
            input.Status = "Yes";

            string serializedInput = JsonConvert.SerializeObject(input);
            StringContent request = new StringContent(serializedInput, Encoding.UTF8, "application/json");

            //Act
            using (actualResponse = await _client.PostAsync("api/Task/AddTask", request))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();

            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.Equal("Success", actualResponseContent);

        }
        [Fact]
        public async void AddTask_Test_For_Missing_Parameters()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            TaskModel input = new TaskModel();
            input.Task1 = "Update UTC document";
            input.StartDate = Convert.ToDateTime("12/10/2019");
            input.EndDate = Convert.ToDateTime("12/10/2020");
            input.Priority = 1;
            input.ProjectId = "MIS123";
            

            string serializedInput = JsonConvert.SerializeObject(input);
            StringContent request = new StringContent(serializedInput, Encoding.UTF8, "application/json");

            //Act
            using (actualResponse = await _client.PostAsync("api/Task/AddTask", request))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();

            }

            //Assert
            Assert.Empty(actualResponseContent);


        }
        [Fact]
        public async void AddParentTask_Test_For_Project()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            ParentTask input = new ParentTask();
            input.ParentTasks = "Update UTC document";
         

            string serializedInput = JsonConvert.SerializeObject(input);
            StringContent request = new StringContent(serializedInput, Encoding.UTF8, "application/json");

            //Act
            using (actualResponse = await _client.PostAsync("api/Task/AddParentTask", request))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();

            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.Equal("Success", actualResponseContent);

        }
    }
}
