using GraduateWork.Helpers.Configuration;
using GraduateWork.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

/*namespace GraduateWork.Tests.Api_Tests
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
        public async Task GetAllProjectApiTest()
        {
            var client = new RestClient(Configurator.AppSettingsApi.URL);

            var result =  await ProjectService.GetAllProjects(Configurator.AppSettingsApi.Authorization, Configurator.AppSettingsApi.Token);



            *//*            var response = client.ExecuteGet(request);
                            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
                        var actual = response1.Result;*//*
            _logger.Info(result.ToString());


*//*            Assert.Multiple(() =>
            {
                Assert.That(response1.Result.Page, Is.EqualTo(_project.Name));
                Assert.That(actualProject.Result.Announcement, Is.EqualTo(_project.Announcement));
                Assert.That(actualProject.Result.ShowAnnouncement, Is.EqualTo(_project.ShowAnnouncement));
                Assert.That(actualProject.Result.SuiteMode, Is.EqualTo(_project.SuiteMode));

            });*//*
        }


    }
}
*//*[JsonPropertyName("page")] public int Page { get; set; }
[JsonPropertyName("prev_page")] public int? PrevPage { get; set; }
[JsonPropertyName("next_page")] public int? NextPage { get; set; }
[JsonPropertyName("last_page")] public int LastPage { get; set; }
[JsonPropertyName("per_page")] public int PerPage { get; set; }
[JsonPropertyName("total")] public int Total { get; set; }
[JsonPropertyName("projects")] public List<Projects> Projects { get; set; } = new();*/

namespace GraduateWork.Tests.Api_Tests
{
    public class GetApiTest : BaseApiTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /*        private const string _failtoken = "testmo_api_eyJpdiI6ImZZa2diTjMySWpteDNSVS90NzBhS1E9PSIsInZhbHVlIjoiZy9RanBQR0xtbG4vRTlPdWV6Q0JrRVNYU2hpSlV3aUE0OWJQZ2xvd0ZmVT0iLCJtYWMiOiJkNzZlZ GNlM2UxZjY5NWQ5ZWY2NjQ1MzU4ZDcxNTk3OTeyM2E3MTU3YTMxM2ZkMzllNTYyNGEyNmI0MzNmMjAzIiwidGFnIjoiIn0=";

                [Test]
                [Order(2)]
                public void AuthorizationCorrectApiTest()
                {

                    var response = ProjectService!.Authorization(Configurator.AppSettingsApi.Authorization, Configurator.AppSettingsApi.Token);

                    Assert.Multiple(() =>
                    {
                        Assert.That(response.Result.Name, Is.EqualTo("Kipyatkov Pavel"));
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
        *//*            var response = client.ExecuteGet(request);

                    _logger.Info(response.Content);

                    dynamic responseObject = JsonConvert.DeserializeObject(response.Content);// десеализуем, что бы можно было сравнить с нашим значением

                    string name = responseObject!.name;
                    Assert.Multiple(() =>
                    {
                        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
                        Assert.That(name, Is.EqualTo(null));
                    });*//*


                }
        */
        [Test]
        [Order(3)]
        public void GetAllProjectApiTest()
        {
            var result = ProjectService!.GetAllProjects();

            Assert.Multiple(() =>
            {
                Assert.That(result.Result.Page, Is.EqualTo(1));
                Assert.That(result.Result.Total, Is.EqualTo(9));
            });
            /*            _logger.Info(result.ToString());

                        Assert.That(result, Is.TypeOf<Result>());*/


            /*            string schemaJson = File.ReadAllText(@"Resources/schema.json");

                        //Создаём экземлпляр JSON-схемы
                        JSchema schema = JSchema.Parse(schemaJson);

                        //Получае тело ответа в виде JSONobject
                        JObject responseData = JObject.Parse(result.Content);

                        //Проверка соответсвтвия ответа JSON - схеме
                        Assert.That(responseData.IsValid(schema));*/

        }
    }
}
