using AutoMapper;
using ControllerFirst.Contexts;
using ControllerFirst.Controllers;
using Xunit;
using Moq;
using FluentAssertions;
using ControllerFirst.Services.Classes;
using ControllerFirst.Services.Interfaces;
using ControllerFirst.DTO.Requests;
using ControllerFirst.DTO.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

public class AuthServiceTests
{
    private readonly Mock<IAccountService> _accountServiceMock;
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IConfiguration> _config;
    private readonly AccountController _accountController;

    public AuthServiceTests()
    {
        _accountServiceMock = new Mock<IAccountService>();
        _accountController = new AccountController(_accountServiceMock.Object);

    }

    [Fact]
    public async Task Register_ShouldReturnSuccess_WhenUserIsCreated()
    {
        var request = new RegisterRequest
        (
            "Test_123",
            "test@example.com",
            "Password123",
            "Password123"
        );

            _accountServiceMock.Setup(x => x.RegisterAsync(request)).Returns(Task.CompletedTask);

            // Act
            var result = await _accountController.Register(request) as OkObjectResult;

            // Assert
            result.StatusCode.Should().Be(200);
    }
}