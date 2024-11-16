using FIAP_PROJETO_CSHARP.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class HomeControllerTests
{
    private readonly HomeController _controller;

    public HomeControllerTests()
    {
       
        var mockLogger = new Mock<ILogger<HomeController>>();
        // Init controller 
        _controller = new HomeController(mockLogger.Object);
    }

    [Fact]
    public void Index_ReturnsViewResult_WithStatusCode200()
    {
        // Act
        var result = _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        int expectedStatusCode = 200;
        int actualStatusCode = viewResult.StatusCode ?? 200;
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }
}
