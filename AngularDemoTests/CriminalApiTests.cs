using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using AngularDemo.Models;
using System.Net.Http;
using AngularDemo.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.Http.Routing;
using Moq;
using System.Linq;
using System.Web.Http.Results;
using System.Net;
using System.Net.Http.Headers;

namespace AngularDemoTests
{
    [TestClass]
    public class CriminalApiTests
    {
        private const string ServiceBaseURL = "http://localhost:50875/";


        [TestMethod]
        public void GetReturnsCriminalWithSameId()
        {
            Guid id = Guid.NewGuid();
            var controller = new CriminalsController();
            CriminalsController._criminals.Add(new Criminal { ID = id, Name = "test" });
            // Act
            IHttpActionResult actionResult = controller.Get(id);
            var contentResult = actionResult as OkNegotiatedContentResult<CriminalDTO>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(id, contentResult.Content.ID);
        }
        [TestMethod]
        public void GetReturnsAllCriminals()
        {
            var controller = new CriminalsController();
            int estCount = CriminalsController._criminals.Count;
            // Act
            var result = controller.Get();
            // Assert

            Assert.AreEqual(estCount, result.Count());
        }
        [TestMethod]
        public void GetReturnsNotFound()
        {
            Guid id = Guid.NewGuid();
            var controller = new CriminalsController();
            CriminalsController._criminals.Add(new Criminal { ID = id, Name = "test" });
            // Act
            IHttpActionResult actionResult = controller.Get(Guid.NewGuid());

            //assert
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
        [TestMethod]
        public void DeleteReturnsOk()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var controller = new CriminalsController();
            CriminalsController._criminals.Add(new Criminal { ID = id, Name = "test" });

            // Act
            IHttpActionResult actionResult = controller.Delete(id);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
        [TestMethod]
        public async Task GetShouldReturnJsonResultForAll()
        {

            List<CriminalDTO> criminal;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:49457/");
                var response = await httpClient.GetAsync("/api/criminals/" );
                criminal = await response.Content.ReadAsAsync<List<CriminalDTO>>();

            }
            Assert.AreEqual(3, criminal.Count);
        }
        [TestMethod]
        public async Task GetShouldReturnJsonResult()
        {
      
            CriminalDTO criminal; List<CriminalDTO> criminals;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:49457/");
                var responseAll = await httpClient.GetAsync("/api/criminals/");
                criminals = await responseAll.Content.ReadAsAsync<List<CriminalDTO>>();
                var response = await httpClient.GetAsync("/api/criminals/" + criminals[0].ID);
                criminal = await response.Content.ReadAsAsync<CriminalDTO>();

            }
            Assert.AreEqual(criminals[0].ID, criminal.ID);
        }
        [TestMethod]
        public async Task GetShouldReturnErrorNotFoundResult()
        {
            Guid id = Guid.NewGuid();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:49457/");
                var response = await httpClient.GetAsync("/api/criminals/" + id);
                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            }

        }
        [TestMethod]
        public async Task PostShouldAddCriminalToCriminals()
        {
            Guid id = Guid.NewGuid();
            //arr
            CriminalDTO dto = new CriminalDTO()
            {
                Name = "test",
                Description = "",
                Reward = 1
            };
            var myContent = JsonConvert.SerializeObject(dto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:49457/");
                var response = await httpClient.PostAsync("/api/criminals/", byteContent);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }

        }
        [TestMethod]
        public async Task PutShouldUpdateCriminal()
        {
            Guid id = Guid.NewGuid();
            //arr

            CriminalDTO criminal; List<CriminalDTO> criminals;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:49457/");
                var responseAll = await httpClient.GetAsync("/api/criminals/");
                criminals = await responseAll.Content.ReadAsAsync<List<CriminalDTO>>();
                var response = await httpClient.GetAsync("/api/criminals/" + criminals[0].ID);
                criminal = await response.Content.ReadAsAsync<CriminalDTO>();

            }
            criminal.Name = "update";
            var myContent = JsonConvert.SerializeObject(criminal);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:49457/");
                var response = await httpClient.PutAsync("/api/criminals/", byteContent);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }

        }
    }
}
