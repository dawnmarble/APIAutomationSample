using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TechTalk.SpecFlow;
using FluentAssertions;
using APIAutomationSample.Helpers;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace APIAutomationSample.Steps
{
    [Binding]
    public class PostSteps
    {
        private IRestResponse result;
        HttpClient client = new HttpClient();
        dynamic jsonBody;

        [Given(@"a (.*) request body")]
        public void GivenARequestBody(string fileName)
        {
            jsonBody = FileUtility.SetPayloadBody(fileName);    
        }

        [When(@"I POST the request")]
        public void WhenIPostTheRequest()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(jsonBody);
            result = client.Execute(request);
        }

        [Then(@"the response should be a (.*) \(""(.*)""\) response")]
        public void ThenTheResponseShouldBeAResponse(int code, string description)
        {
            int statusCode = (int)result.StatusCode;
            statusCode.Should().Be(code);
            result.StatusDescription.Should().Be(description);
        }

        [Then(@"the response body should be what I expect")]
        public void ThenTheResponseBodyShouldBeWhatIExpect()
        {
            var jObject = JObject.Parse(result.Content);
            jObject.GetValue("title").ToString().Should().Contain("foo");
            jObject.GetValue("body").ToString().Should().Contain("bar");
            jObject.GetValue("userId").ToObject<int>().Should().Be(1);
            jObject.GetValue("id").ToString().Should().NotBeNullOrEmpty();
        }
    }
}