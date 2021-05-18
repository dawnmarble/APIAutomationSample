using TechTalk.SpecFlow;
using FluentAssertions;
using APIAutomationSample.Helpers;
using RestSharp;
using Newtonsoft.Json;

namespace APIAutomationSample.Steps
{
    [Binding]
    public class StepDefinitions : TechTalk.SpecFlow.Steps
    {
        private IRestResponse result;
        dynamic jsonBody;
        private RestClient client;

        public StepDefinitions()
        {
            client = new RestClient("https://jsonplaceholder.typicode.com/");
        }

        [Given(@"a (.*) request body")]
        public void GivenARequestBody(string fileName)
        {
            jsonBody = FileUtility.SetPayloadBody(fileName);    
        }

        [Given(@"GET all Posts")]
        [When(@"GET all Posts")]
        public void WhenGETAllPosts()
        {
            var request = new RestRequest("posts", Method.GET);
            result = client.Execute(request);
        }

        [Given(@"I execute a '(.*)' Post where PostId is (.*)")]
        [When(@"I execute a '(.*)' Post where PostId is (.*)")]
        public void WhenIExecuteAPostWherePostIdIs(string method, string value)
        {
            string resource = "posts/" + value;
            var request = new RestRequest(resource, APIHelper.PickAMethod(method));
            result = client.Execute(request);
        }

        [Given(@"I call '(.*)' Post where (.*) is (.*)")]
        public void GivenICallAPostWhereIs(string method, string parameter, string value)
        {
            string resource = "comments?{parameter}={value}";
            var request = new RestRequest(resource, APIHelper.PickAMethod(method));
            request.AddUrlSegment("parameter", parameter);
            request.AddUrlSegment("value", value);
            result = client.Execute(request);
        }

        [When(@"I POST the request")]
        public void WhenIPostTheRequest()
        {

            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(jsonBody);
            result = client.Execute(request);
        }

        [Then(@"the response body should not be empty")]
        public void ThenTheResponseBodyShouldNotBeEmpty()
        {
            result.Content.Should().NotBeNullOrEmpty();
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
            Post jsonRequestBody = JsonConvert.DeserializeObject<Post>(jsonBody);
            Post jsonResponseBody = JsonConvert.DeserializeObject<Post>(result.Content);

            jsonResponseBody.title.Should().Be(jsonRequestBody.title);
            jsonResponseBody.body.Should().Be(jsonRequestBody.body);
            jsonResponseBody.userId.Should().Be(jsonRequestBody.userId);
        }

        [Then(@"the comment response body should be what I expect")]
        public void ThenCommentTheResponseBodyShouldBeWhatIExpect()
        {
            Comment jsonRequestBody = JsonConvert.DeserializeObject<Comment>(jsonBody);
            Comment jsonResponseBody = JsonConvert.DeserializeObject<Comment>(result.Content);

            jsonResponseBody.body.Should().Be(jsonRequestBody.body);
            jsonResponseBody.name.Should().Be(jsonRequestBody.name);
            jsonResponseBody.email.Should().Be(jsonRequestBody.email);
        }
    }
}