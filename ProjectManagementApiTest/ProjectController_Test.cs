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

namespace ProjectManagementApiTest
{
    public class ProjectController_Test
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public ProjectController_Test()
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
            List<ProjectDetails> actualListOfProjects = new List<ProjectDetails>();
            //Act
            using (actualResponse = await _client.GetAsync("api/Project/Get"))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();
                actualListOfProjects = JsonConvert.DeserializeObject<List<ProjectDetails>>(actualResponseContent);
            }
            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.NotEmpty(actualListOfProjects);

        }
        [Fact]
        public async void GetManagers_Test()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            List<Projects> actualListOfManagers = new List<Projects>();
            //Act
            using (actualResponse = await _client.GetAsync("api/Project/GetManagers"))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();
                actualListOfManagers = JsonConvert.DeserializeObject<List<Projects>>(actualResponseContent);
            }
            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.NotEmpty(actualListOfManagers);

        }
        [Fact]
        public async void GetProjects_Test()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            List<Projects> actualListOfProjectNames = new List<Projects>();
            //Act
            using (actualResponse = await _client.GetAsync("api/Project/GetProjects"))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();
                actualListOfProjectNames = JsonConvert.DeserializeObject<List<Projects>>(actualResponseContent);
            }
            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.NotEmpty(actualListOfProjectNames);

        }
        [Fact]
        public async void Addproject_Test_For_New_Project()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            Projects input = new Projects();
            input.Project = "Rating";
            input.StartDate = Convert.ToDateTime("12/10/2019");
            input.EndDate = Convert.ToDateTime("12/10/2020");
            input.Priority = 1;

            string serializedInput = JsonConvert.SerializeObject(input);
            StringContent request = new StringContent(serializedInput, Encoding.UTF8, "application/json");

            //Act
            using (actualResponse = await _client.PostAsync("api/Project/AddProject", request))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();

            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);
            Assert.Equal("Success", actualResponseContent);

        }
        [Fact]
        public async void Addproject_Test_For_Already_Added_project()
        {
            //Arrange
            HttpResponseMessage actualResponse = null;
            string actualResponseContent = string.Empty;
            Projects input = new Projects();
            input.Project = "MIS";
           
            input.StartDate = Convert.ToDateTime("12/10/2019");
            input.EndDate = Convert.ToDateTime("12/10/2020");
            input.Priority = 1;

            string serializedInput = JsonConvert.SerializeObject(input);
            StringContent request = new StringContent(serializedInput, Encoding.UTF8, "application/json");

            //Act
            using (actualResponse = await _client.PostAsync("api/Project/AddProject", request))
            {
                actualResponseContent = await actualResponse.Content.ReadAsStringAsync();

            }

            //Assert
            Assert.Empty(actualResponseContent);
           

        }
    }
}
