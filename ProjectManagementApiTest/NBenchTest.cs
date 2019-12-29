using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NBench;
using Newtonsoft.Json;
using ProjectManagementApi;
using ProjectManagementApi.Models;
using Xunit;

namespace ProjectManagementApiTest
{
    public class NBenchTest
    {
        private Counter _opCounter;
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public NBenchTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        public void SetUp(BenchmarkContext context)
        {
            _opCounter = context.GetCounter("MyCounter");
        }
        [PerfBenchmark(NumberOfIterations =10,RunMode =RunMode.Throughput,RunTimeMilliseconds =1000,TestMode =TestMode.Measurement)]
        [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public async void BenchmarkMethod(BenchmarkContext context)
        {
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
         
            _opCounter.Increment();
        }
    }
}
