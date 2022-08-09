using OrderService.iikoTransportApi;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace OrderService.iikoTransportApi.Tests
{
    public  class iikoTransportClientTests
    {
        private readonly ITestOutputHelper _testOutput;

        public iikoTransportClientTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void GetAccessTokenTest_InputValidApiLogin_ReturnToken()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient("962107c6-21d");
            // Act
            var result = client.GetAccessTokenAsync();
            // Assert
            _testOutput.WriteLine(result.Result.Token);
            Assert.NotNull(result.Result.Token);
        }

        [Fact]
        public void GetAccessTokenTest_InputInvalidApiLogin_ThrowException()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient("962107c6-25d");
            // Act
            Assert.ThrowsAny<System.AggregateException>(() =>
            {
                //invalid apiLogin
                var result = client.GetAccessTokenAsync();
                _testOutput.WriteLine(result.Result.ToString());

            });
        }

        [Fact]
        public void GetAutorizedClient_InputToken_ReturnClinet()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient("962107c6-21d");

            // Act
            var result = client.GetAutorizedClient();
            // Assert
            _testOutput.WriteLine(result.DefaultRequestHeaders.ToString());
            Assert.NotNull(result);
        }


        [Fact]
        public void GetOrganizationsTest_InputNull_ReturnOrganizationList()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient("962107c6-21d");
            // Act
            var org = client.GetOrganizationsAsync();
            // Assert
            foreach(var item in org.Result.Organizations)
            {
                _testOutput.WriteLine(item.Id);
                _testOutput.WriteLine(item.Name);

            }
            Assert.NotNull(org.Result.Organizations);
        }


    }
}
