using GraduateWork.Helpers.Configuration;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Tests.Api_Tests
{
    public class GetApiTest : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private const string _failtoken = "testmo_api_eyJpdiI6ImZZa2diTjMySWpteDNSVS90NzBhS1E9PSIsInZhbHVlIjoiZy9RanBQR0xtbG4vRTlPdWV6Q0JrRVNYU2hpSlV3aUE0OWJQZ2xvd0ZmVT0iLCJtYWMiOiJkNzZlZ GNlM2UxZjY5NWQ5ZWY2NjQ1MzU4ZDcxNTk3OTeyM2E3MTU3YTMxM2ZkMzllNTYyNGEyNmI0MzNmMjAzIiwidGFnIjoiIn0=";

        [Test]
        [Order(2)]
        public void AuthorizationCorrectApiTest()
        {
            //Setup Rest Client

            var client = new RestClient(Configurator.AppSettingsApi.URL);
                        
            //Setup Request
            var request = ProjectService.Authorization(Configurator.AppSettingsApi.Authorization, Configurator.AppSettingsApi.Token);

            //Execute Request
            var response = client.ExecuteGet(request);

            _logger.Info(response.Content);

            dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);// десеализуем, что бы можно было сравнить с нашим значением

            string name = responseObject!.name;
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(name, Is.EqualTo("Kipyatkov Pavel"));
            });
        }
        [Test]
        [Order(1)]
        //AFE
        public void IncorrectAuthorizationApiTest()
        {

            //Setup Rest Client

            var client = new RestClient(Configurator.AppSettingsApi.URL);

            //Setup Request
            var request = ProjectService.Authorization(Configurator.AppSettingsApi.Authorization, _failtoken);

            //Execute Request
            var response = client.ExecuteGet(request);

            _logger.Info(response.Content);

            dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);// десеализуем, что бы можно было сравнить с нашим значением

            string name = responseObject!.name;
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
                Assert.That(name, Is.EqualTo(null));
            });
        }

        [Test]
        [Order(3)]
        public void AuthorizationCorrectApiTest()
        {
            //Setup Rest Client

            var client = new RestClient(Configurator.AppSettingsApi.URL);

            //Setup Request
            var request = ProjectService.Authorization(Configurator.AppSettingsApi.Authorization, Configurator.AppSettingsApi.Token);

            //Execute Request
            var response = client.ExecuteGet(request);

            _logger.Info(response.Content);

            dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);// десеализуем, что бы можно было сравнить с нашим значением

            string name = responseObject!.name;
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(name, Is.EqualTo("Kipyatkov Pavel"));
            });
        }


    }
}
