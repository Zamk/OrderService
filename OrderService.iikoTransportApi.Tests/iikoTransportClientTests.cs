using OrderService.iikoTransportApi;
using System.Net.Http;
using System.Collections.Generic;
using System;
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
            
            var ex = Assert.ThrowsAny<System.AggregateException>(() =>
            {
                //invalid apiLogin
                var result = client.GetAccessTokenAsync();
                result.Result.ToString();

            });
           
            _testOutput.WriteLine(ex.Message);
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

        [Fact]
        public void GetTerminalGroupsAsync_InputOrgIds_ReturnTerminalGroups()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient("962107c6-21d");
            // Act
            var org = client.GetOrganizationsAsync().Result;

            List<Guid> orgIds = new List<Guid>();

            foreach (var item in org.Organizations)
                orgIds.Add(Guid.Parse(item.Id));

            var response = client.GetTerminalGroupsAsync(orgIds).Result;
            // Assert
            foreach(var orgWTerminals in response.TerminalGroups)
            {
                _testOutput.WriteLine("Organization Id: " + orgWTerminals.OrganizationId);

                foreach(var terminal in orgWTerminals.Items)
                {
                    Assert.NotEqual(Guid.Empty, terminal.Id);
                    _testOutput.WriteLine("Key: " + terminal.Id);
                    _testOutput.WriteLine("Name: " + terminal.Name);
                    _testOutput.WriteLine("Organization Id: " + terminal.OrganizationId);
                    _testOutput.WriteLine("Address: " + terminal.Address + "\n");
                }
            }

        }

        [Fact]
        public void GetNomeclatureAsync_InputOrgId_ReturnNomeclatureGroups()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient("962107c6-21d");
            // Act
            var org = client.GetOrganizationsAsync().Result;

            Guid orgId = Guid.Parse( org.Organizations[0].Id );

            var response = client.GetNomenclatureAsync(orgId).Result;

            // Assert
            _testOutput.WriteLine("CorellationId: " + response.CorrelationId);

            _testOutput.WriteLine("Groups:\n  Groups.Count: " + response.Groups.Count);
            foreach (var group in response.Groups)
            {
                _testOutput.WriteLine("  " + group?.Name);

            }

            _testOutput.WriteLine("ProductCategories:\n  ProductCategories.Count: " + response.ProductCategories.Count);

            foreach (var category in response.ProductCategories)
            {
                _testOutput.WriteLine("  " + category?.Name);

            }

            _testOutput.WriteLine("Products:\n  Products.Count: " + response.Products.Count);

            foreach (var product in response.Products)
            {
                _testOutput.WriteLine("  " + product?.Name);

            }

            _testOutput.WriteLine("Sizes:\n  Sizes.Count: " + response.Sizes.Count);

            foreach (var size in response.Sizes)
            {
                _testOutput.WriteLine("  " + size?.Name);

            }

        }
    }
}
