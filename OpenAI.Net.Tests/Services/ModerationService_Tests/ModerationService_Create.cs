﻿using System.Net;
using OpenAI.Net.Models.Requests;
using OpenAI.Net.Services;

namespace OpenAI.Net.Tests.Services.ModerationService_Tests
{
    internal class ModerationService_Create : BaseServiceTest
    {
        const string responseJson = @"{
  ""id"": ""modr-5MWoLO"",
  ""model"": ""text-moderation-001"",
  ""results"": [
    {
      ""categories"": {
        ""hate"": false,
        ""hate/threatening"": true,
        ""self-harm"": false,
        ""sexual"": false,
        ""sexual/minors"": false,
        ""violence"": true,
        ""violence/graphic"": false
      },
      ""category_scores"": {
        ""hate"": 0.22714105248451233,
        ""hate/threatening"": 0.4132447838783264,
        ""self-harm"": 0.005232391878962517,
        ""sexual"": 0.01407341007143259,
        ""sexual/minors"": 0.0038522258400917053,
        ""violence"": 0.9223177433013916,
        ""violence/graphic"": 0.036865197122097015
      },
      ""flagged"": true
    }
  ]
}            ";



        [TestCase(true, HttpStatusCode.OK, responseJson, null, Description = "Successfull Request", TestName = "Create_When_Success")]
        [TestCase(false, HttpStatusCode.BadRequest, ErrorResponseJson, "an error occured", Description = "Failed Request", TestName = "Create_When_Fail")]
        public async Task Create(bool isSuccess, HttpStatusCode responseStatusCode, string responseJson, string errorMessage)
        {
            var httpClient = GetHttpClient(responseStatusCode, responseJson, "/v1/moderations");

            var service = new ModerationService(httpClient);
            var request = new ModerationRequest("input text") { Model = "test" };
            var response = await service.Create(request);

            Assert.That(request.Input, Is.EqualTo("input text".ToList()));
            Assert.That(response.Result?.Results.Length > 0, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Id != null, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Model != null, Is.EqualTo(isSuccess));

            Assert.That(response.Result?.Results?[0]?.Flagged == true, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.Violence == true, Is.EqualTo(isSuccess)); ;
            Assert.That(response.Result?.Results?[0]?.Categories.Hate == false, Is.EqualTo(isSuccess)); ;
            Assert.That(response.Result?.Results?[0]?.Categories.ViolenceGraphic == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.SelfHarm == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.HateThreatening == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.Sexual == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.SexualMinors == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Hate == 0.22714105248451233, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.HateThreatening == 0.4132447838783264, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.SelfHarm == 0.005232391878962517, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Sexual == 0.01407341007143259, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Violence == 0.9223177433013916, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.ViolenceGraphic == 0.036865197122097015, Is.EqualTo(isSuccess));

            AssertResponse(response,isSuccess,errorMessage,responseStatusCode);
        }

        [TestCase(true, HttpStatusCode.OK, responseJson, null, Description = "Successfull Request", TestName = "CreateList_When_Success")]
        [TestCase(false, HttpStatusCode.BadRequest, ErrorResponseJson, "an error occured", Description = "Failed Request", TestName = "CreateList_When_Fail")]
        public async Task CreateList(bool isSuccess, HttpStatusCode responseStatusCode, string responseJson, string errorMessage)
        {
            var httpClient = GetHttpClient(responseStatusCode, responseJson, "/v1/moderations");

            var service = new ModerationService(httpClient);
            var request = new ModerationRequest(new List<string>() { "input text" }) { Model = "test" };
            var response = await service.Create(request);

            Assert.That(request.Input.FirstOrDefault(), Is.EqualTo("input text"));
            Assert.That(response.Result?.Results.Length > 0, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Id != null, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Model != null, Is.EqualTo(isSuccess));

            Assert.That(response.Result?.Results?[0]?.Flagged == true, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.Violence == true, Is.EqualTo(isSuccess)); ;
            Assert.That(response.Result?.Results?[0]?.Categories.Hate == false, Is.EqualTo(isSuccess)); ;
            Assert.That(response.Result?.Results?[0]?.Categories.ViolenceGraphic == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.SelfHarm == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.HateThreatening == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.Sexual == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.SexualMinors == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Hate == 0.22714105248451233, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.HateThreatening == 0.4132447838783264, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.SelfHarm == 0.005232391878962517, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Sexual == 0.01407341007143259, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Violence == 0.9223177433013916, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.ViolenceGraphic == 0.036865197122097015, Is.EqualTo(isSuccess));

            AssertResponse(response, isSuccess, errorMessage, responseStatusCode);
        }

        [TestCase(true, HttpStatusCode.OK, responseJson, null, Description = "Successfull Request", TestName = "CreateExtensionMethod_When_Success")]
        [TestCase(false, HttpStatusCode.BadRequest, ErrorResponseJson, "an error occured", Description = "Failed Request", TestName = "CreateExtensionMethod_When_Fail")]
        public async Task CreateExtensionMethod(bool isSuccess, HttpStatusCode responseStatusCode, string responseJson, string errorMessage)
        {
            var jsonRequest = "";
            var httpClient = GetHttpClient(responseStatusCode, responseJson, "/v1/moderations", "https://api.openai.com", (request) => {
                jsonRequest = request.Content.ReadAsStringAsync().Result;
            });

            var service = new ModerationService(httpClient);
            var response = await service.Create("input text", "test");

            Assert.That(jsonRequest.Contains(@"""input"":[""input text""]"));
            Assert.That(jsonRequest.Contains(@"""model"":""test"""));

            Assert.That(response.Result?.Results.Length > 0, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Id != null, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Model != null, Is.EqualTo(isSuccess));

            Assert.That(response.Result?.Results?[0]?.Flagged == true, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.Violence == true, Is.EqualTo(isSuccess)); ;
            Assert.That(response.Result?.Results?[0]?.Categories.Hate == false, Is.EqualTo(isSuccess)); ;
            Assert.That(response.Result?.Results?[0]?.Categories.ViolenceGraphic == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.SelfHarm == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.HateThreatening == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.Sexual == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.SexualMinors == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Hate == 0.22714105248451233, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.HateThreatening == 0.4132447838783264, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.SelfHarm == 0.005232391878962517, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Sexual == 0.01407341007143259, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Violence == 0.9223177433013916, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.ViolenceGraphic == 0.036865197122097015, Is.EqualTo(isSuccess));

            AssertResponse(response, isSuccess, errorMessage, responseStatusCode);
        }

        [TestCase(true, HttpStatusCode.OK, responseJson, null, Description = "Successfull Request", TestName = "CreateListExtensionMethod_When_Success")]
        [TestCase(false, HttpStatusCode.BadRequest, ErrorResponseJson, "an error occured", Description = "Failed Request", TestName = "CreateListExtensionMethod_When_Fail")]
        public async Task CreateListExtensionMethod(bool isSuccess, HttpStatusCode responseStatusCode, string responseJson, string errorMessage)
        {
            var jsonRequest = "";
            var httpClient = GetHttpClient(responseStatusCode, responseJson, "/v1/moderations", "https://api.openai.com", (request) => {
                jsonRequest = request.Content.ReadAsStringAsync().Result;
            });

            var service = new ModerationService(httpClient);
            var response = await service.Create(new List<string>() { "input text" }, "test");

            Assert.That(jsonRequest.Contains(@"""input"":[""input text""]"));
            Assert.That(jsonRequest.Contains(@"""model"":""test"""));

            Assert.That(response.Result?.Results.Length > 0, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Id != null, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Model != null, Is.EqualTo(isSuccess));

            Assert.That(response.Result?.Results?[0]?.Flagged == true, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.Violence == true, Is.EqualTo(isSuccess)); ;
            Assert.That(response.Result?.Results?[0]?.Categories.Hate == false, Is.EqualTo(isSuccess)); ;
            Assert.That(response.Result?.Results?[0]?.Categories.ViolenceGraphic == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.SelfHarm == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.HateThreatening == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.Sexual == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.Categories.SexualMinors == false, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Hate == 0.22714105248451233, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.HateThreatening == 0.4132447838783264, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.SelfHarm == 0.005232391878962517, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Sexual == 0.01407341007143259, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.Violence == 0.9223177433013916, Is.EqualTo(isSuccess));
            Assert.That(response.Result?.Results?[0]?.CategoryScores.ViolenceGraphic == 0.036865197122097015, Is.EqualTo(isSuccess));

            AssertResponse(response, isSuccess, errorMessage, responseStatusCode);
        }
    }
}
