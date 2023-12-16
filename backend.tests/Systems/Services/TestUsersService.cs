using backend.tests.Fixtures;
using backend.tests.Helpers;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;

namespace backend.tests.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetUsers_WhenCalled_InvokeHttpGetRequest()
        {
            // Arrange
            var exptectedUsers = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(exptectedUsers);
            var httpClient = new HttpClient(handlerMock.Object);
            var service = new UsersService(httpClient);

            // Act
            await service.GetUsers();

            // Assert
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(
                    req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetUser_WhenCalled_InvokeHttpGetRequest()
        {
            // Arrange
            var userId = 1;
            var exptectedUser = UsersFixture.GetTestUser(userId);
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResource(exptectedUser);
            var httpClient = new HttpClient(handlerMock.Object);
            var service = new UsersService(httpClient);

            // Act
            await service.GetUser(userId);

            // Assert
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(
                    req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetUsers_WhenCalled_ReturnsUsers()
        {
            // Arrange
            var exptectedUsers = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(exptectedUsers);
            var httpClient = new HttpClient(handlerMock.Object);
            var service = new UsersService(httpClient);

            // Act
            var users = await service.GetUsers();

            // Assert
            users.Should().BeOfType<List<User>>();
            // Assert.Equal(exptectedUsers, users);
        }

        [Fact]
        public async Task GetUser_WhenUserDoesntExist_Returns404()
        {
            // Arrange
            var userId = 99;
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicReturn404(userId);
            var httpClient = new HttpClient(handlerMock.Object);
            var service = new UsersService(httpClient);

            // Act
            var (user, statusCode) = await service.GetUser(userId);

            // Assert that the status code is 404
            Assert.Equal(HttpStatusCode.NotFound, statusCode);
            Assert.Null(user);
        }




    }
}
