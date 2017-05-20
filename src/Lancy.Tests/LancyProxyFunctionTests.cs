namespace Lancy.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Amazon.Lambda.APIGatewayEvents;
    using Amazon.Lambda.TestUtilities;
    using Xunit;
    using Lancy;
    using Shouldly;

    public class LancyProxyFunctionTests
    {
        [Fact]
        public async Task Get_over_http()
        {
            var lancy = new LancyProxyFunction();
            var handler = new OwinHttpMessageHandler(lancy.AppFunc);
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://example.com")
            };

            var response = await client.GetAsync("");
            var body = await response.Content.ReadAsStringAsync();
            
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            body.ShouldStartWith("Hello");
        }

        [Fact]
        public async Task Get_over_api_proxy()
        {
            var lancy = new LancyProxyFunction();
            var context = new TestLambdaContext();
            var request = new APIGatewayProxyRequest
            {
                HttpMethod = "GET",
                Path = "/"
            };
            var response = await lancy.FunctionHandler(request, context);

            response.StatusCode.ShouldBe(200);
            response.Body.ShouldStartWith("Hello");
        }
    }
}
