using Backend.Controllers;
using Backend.Models;
using Backend.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace backend.tests.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task GetUsers_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange
        var mockUserService = new Mock<IUsersService>();
        var controller = new UsersController(mockUserService.Object);

        // Act
        var result = await controller.GetUsers();

        // Assert
        Assert.IsType<OkObjectResult>(result);

    }

    [Fact]
    public async Task GetUsers_OnSuccess_InvokesUserServiceExactlyOnce()
    {
        // Arrange
        var mockUserService = new Mock<IUsersService>();
        mockUserService.Setup(service => service.GetUsers()).ReturnsAsync(new List<User>());
        var controller = new UsersController(mockUserService.Object);

        // Act
        var result = await controller.GetUsers();

        // Assert
        mockUserService.Verify(service => service.GetUsers(), Times.Once);
    }

    [Fact]
    public async Task GetUsers_OnSuccess_ReturnsListOfUsers()
    {
        // Arrange
        var mockUserService = new Mock<IUsersService>();
        mockUserService.Setup(service => service.GetUsers()).ReturnsAsync(new List<User>());
        var controller = new UsersController(mockUserService.Object);

        // Act
        var result = await controller.GetUsers();

        // Assert
        result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeOfType<List<User>>();
    }

}