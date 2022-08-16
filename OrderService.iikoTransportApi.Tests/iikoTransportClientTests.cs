using OrderService.iikoTransportApi;
using System.Net.Http;
using System.Threading;
using System.Collections.Generic;
using System;
using Xunit;
using Xunit.Abstractions;
using OrderService.iikoTransportApi.Models;

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
        public void GetNomeclatureAsync_InputOrgId_ReturnNomeclature()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient("962107c6-21d");
            // Act
            var org = client.GetOrganizationsAsync().Result;

            Guid orgId = Guid.Parse( org.Organizations[0].Id );

            var response = client.GetNomenclatureAsync(orgId).Result;

            // Assert
            _testOutput.WriteLine("CorellationId: " + response.CorrelationId);
            Assert.NotEqual(Guid.Empty, response.CorrelationId);

            _testOutput.WriteLine("Groups:\n  Groups.Count: " + response.Groups.Count);
            foreach (var group in response.Groups)
            {
                Assert.NotEqual(Guid.Empty, group.Id);
                _testOutput.WriteLine("  " + group?.Name);

            }

            _testOutput.WriteLine("ProductCategories:\n  ProductCategories.Count: " + response.ProductCategories.Count);

            foreach (var category in response.ProductCategories)
            {
                Assert.NotEqual(Guid.Empty, category.Id);
                _testOutput.WriteLine("  " + category?.Name);

            }

            _testOutput.WriteLine("Products:\n  Products.Count: " + response.Products.Count);

            foreach (var product in response.Products)
            {
                Assert.NotEqual(Guid.Empty, product.Id);
                _testOutput.WriteLine("  " + product?.Name + ", type: " + product?.Type);
                
            }

            _testOutput.WriteLine("Sizes:\n  Sizes.Count: " + response.Sizes.Count);

            foreach (var size in response.Sizes)
            {
                Assert.NotEqual(Guid.Empty, size.Id);
                _testOutput.WriteLine("  " + size?.Name);

            }

        }

        [Fact]
        public void CreateDeliveryAsync_InputTestOrder_ReturnOrderInfo()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient("962107c6-21d");

            Guid orgId = Guid.Parse("6c237432-a50c-49a1-8309-bd926ba2d55f");
            Guid terminalGroupId = Guid.Parse("3e8c1d46-33b1-f9b1-0179-13c5647c00ce");

            Customer customer = new Customer();
            customer.Gender = "Male";
            customer.Name = "OrderService";
            //customer.Surname = "";
            customer.Comment = "Test customer";
            
            CreateDeliveryOrder order = new CreateDeliveryOrder();
            order.Customer = customer;
            order.Comment = "Test order";
            order.Phone = "+79999999999";
            order.OrderServiceType = "DeliveryByClient";

            List<OrderedProduct> items = new List<OrderedProduct>();
            
            items.Add(new OrderedProduct()
            {
                Type = "Product",
                Amount = 1,
                Comment = "test",
                ProductId = Guid.Parse("512e1749-83c2-44a8-955c-f621984e1e6d")
                
            });

            order.Items = items;

            // Act
            var response = client.CreateDeliveryAsync(orgId, terminalGroupId, order).Result;

            // Assert
            Assert.NotNull(response);
            Assert.NotEqual(Guid.Empty, response.OrderInfo.Id);

            _testOutput.WriteLine("CorellationId: " + response.CorrelationId);
            _testOutput.WriteLine("Order Id: " + response?.OrderInfo?.Id);
            _testOutput.WriteLine("Order CreationStatus: " + response?.OrderInfo?.CreationStatus);
            _testOutput.WriteLine("Order ErrorDescription: " + response?.ErrorDescription);
            _testOutput.WriteLine("Order Error: " + response?.Error);
        }

        // todo: Test for GetDeliveryOrderInfo
        [Fact]
        public void GetDeliveryOrderInfo_InputDekiveryOrderId_ReturnDeliveryOrderInfo()
        {
            // Arrange
            iikoTransportClient client = new iikoTransportClient("962107c6-21d");

            Guid orderId = Guid.Parse("bde24862-577a-41c8-8eb8-dd1fc837ebde");
            Guid organizationId = Guid.Parse("6c237432-a50c-49a1-8309-bd926ba2d55f");

            List<Guid> orderIds = new List<Guid> { orderId };

            // Act
            var response = client.GetDeliveryOrderInfo(organizationId, orderIds).Result;

            // Assert
            Assert.NotNull(response);

            _testOutput.WriteLine("Orders.Count: " + response.Orders.Count.ToString());
            
            foreach(var order in response.Orders)
            {
                Assert.NotNull(order);
                _testOutput.WriteLine("Order Id: " + order.Id);
                _testOutput.WriteLine("Order ExternalNumber: " + order.ExternalNumber);
                _testOutput.WriteLine("Order CreationStatus: " + order.CreationStatus);
                _testOutput.WriteLine("Order ErrorInfo: " + order.ErrorInfo);
            }
        }

        [Fact]
        public void TokenStorage_TokenRenew_Test()
        {
            // Arrang
            iikoTransportClient client = new iikoTransportClient("962107c6-21d");

            // Act

            for(int i = 0; i < 15; i++)
            {
                // Act
                var result = client.GetAutorizedClient();
                // Assert
                _testOutput.WriteLine(result.DefaultRequestHeaders.ToString());
                Assert.NotNull(result);
                Assert.NotNull(result.DefaultRequestHeaders);

                Thread.Sleep(10000);
            }

            // Assert
        }
    }
}
