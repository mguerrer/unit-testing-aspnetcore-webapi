using System;
using RestSharp;
using Xunit;
using Xunit.Abstractions;

namespace jira_tests
{
    public class JiraApiTest
    {
        private readonly ITestOutputHelper output;
        public JiraApiTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Issue_Add_Comment()
        {
            var client = new RestClient("https://marcosguerrerow.atlassian.net/rest/api/2/issue/PRO-10/comment");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic bWFyY29zZ3VlcnJlcm93QGhvdG1haWwuY29tOlZpMHJYUjJlVW9wcldJd0tZU3JwMTczMA==");
            var body = @"{""body"":""Comment from GitHub pipeline...""}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            output.WriteLine(response.Content);

            // Assert
            output.WriteLine("Status code= " + response.StatusCode);
        }
    }
}

