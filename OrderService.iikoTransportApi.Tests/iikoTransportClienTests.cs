using OrderService.iikoTransportApi;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace OrderService.iikoTransportApi.Tests
{
    public  class iikoTransportClienTests
    {
        private readonly ITestOutputHelper _testOutput;

        public iikoTransportClienTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void GetAccessTokenTest_InputValidApiLogin_ReturnToken()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient();
            // Act
            var result = client.GetAccessToken("962107c6-21d");
            // Assert
            _testOutput.WriteLine(result.Result.Token);
            Assert.NotNull(result.Result.Token);
        }

        [Fact]
        public void GetAccessTokenTest_InputInvalidApiLogin_ThrowException()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient();
            // Act
            Assert.ThrowsAny<System.AggregateException>(() =>
            {
                //invalid apiLogin
                var result = client.GetAccessToken("962107c6-25d");
                _testOutput.WriteLine(result.Result.ToString());

            });
        }
    }
}
