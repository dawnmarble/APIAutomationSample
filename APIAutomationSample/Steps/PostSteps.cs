using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace APIAutomationSample.Steps
{
    [Binding]
    public class PostSteps
    {
        private HttpResponseMessage result;
        HttpClient client = new HttpClient();

        [Given(@"a (.*) request body")]
        public void GivenARequestBody(string type)
        {
            //take request 'type' JsonBody from Payloads

            //returns jsonBody
        }

        [When(@"I POST the request")]
        public async void WhenIPostTheRequest(string jsonBody)
        {
            var content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
            result = await client.PostAsync("https://jsonplaceholder.typicode.com/posts/1", content);
        }

        [Then(@"the response should be a (.*) \(""(.*)""\) response")]
        public void ThenTheResponseShouldBeAResponse(int code, string description)
        {
            result.StatusCode.Should().Be(code);
            result.ReasonPhrase.Should().Be(description);
        }

        [Then(@"the response body should be what I expect")]
        public void ThenTheResponseBodyShouldBeWhatIExpect()
        {
            result.Content.ToString().Should().Contain("id");
            //parse the Json response and assert each property
        }


    }
}
