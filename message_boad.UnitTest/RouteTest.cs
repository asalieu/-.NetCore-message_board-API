using message_board;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace message_boad.UnitTest
{
    public class RouteTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        private const string dockerUrl = "http://localhost:9443/swagger";

        private const string localUrl = "http://localhost:3003";
        public RouteTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        // This method test access to all http request to message_board API hosted on the docker container
        [Theory]
        [InlineData(dockerUrl)] 
        public async Task TestHttpRequestToContainerHosting(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        //This method test access to all http request to message_board API hosted locally on the system
        [Theory]
        [InlineData(localUrl)] 
        public async Task TestHttpRequestToLocalHosting(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
