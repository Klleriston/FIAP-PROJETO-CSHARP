using FIAP_PROJETO_CSHARP.Controllers;
using FIAP_PROJETO_CSHARP.Data;
using FIAP_PROJETO_CSHARP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using System.Threading.Tasks;
using Xunit;

public class AccountControllerTests
{
    private readonly ApplicationDbContext _context;
    private readonly AccountController _controller;
    private readonly Mock<IAuthenticationService> _authenticationServiceMock;

    public AccountControllerTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        _context = new ApplicationDbContext(options);

       
        _controller = new AccountController(_context);

       
        _authenticationServiceMock = new Mock<IAuthenticationService>();
        var serviceProviderMock = new Mock<IServiceProvider>();
        serviceProviderMock
            .Setup(sp => sp.GetService(typeof(IAuthenticationService)))
            .Returns(_authenticationServiceMock.Object);

        var httpContext = new DefaultHttpContext
        {
            RequestServices = serviceProviderMock.Object
        };

        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        var urlHelperMock = new Mock<IUrlHelper>();
        urlHelperMock
            .Setup(x => x.Action(It.IsAny<UrlActionContext>()))
            .Returns("redirectUrl");

        _controller.Url = urlHelperMock.Object;
    }
  
    [Fact]
    public async Task Login_ReturnsRedirectToActionResult_WhenCredentialsAreValid()
    {
        // Arrange
        var user = new User
        {
            Email = "test@domain.com",
            Password = BCrypt.Net.BCrypt.HashPassword("password"),
            Username = "testuser" 
        };
        _context.Users.Add(user);
        _context.SaveChanges();

        var loginModel = new Login { Email = "test@domain.com", Password = "password" };

        // Act
        var result = await _controller.Login(loginModel);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
        Assert.Equal("Truck", redirectResult.ControllerName);
    }
}
