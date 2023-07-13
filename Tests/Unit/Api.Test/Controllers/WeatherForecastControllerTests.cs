using Api.Controllers;
using AutoFixture;
using ControllerService.Interfaces.Weather;
using ControllerService.Models.Weather;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Api.Test.Controllers;

public class WeatherForecastControllerTests
{
    WeatherForecastController sut;
    Mock<ILogger<WeatherForecastController>> loggerMock;
    Mock<IWeatherForecastService> weatherForecastServiceMock;
    Moq.Language.Flow.ISetup<IWeatherForecastService, Task<WeatherForecastModel>> setupMockGetWeatherForecastAsync;

    Fixture fixture;

    [SetUp]
    public void Setup()
    {
        loggerMock = new Mock<ILogger<WeatherForecastController>>();

        weatherForecastServiceMock = new Mock<IWeatherForecastService>();
        setupMockGetWeatherForecastAsync = weatherForecastServiceMock.Setup(x => x.GetWeatherForecastAsync(It.IsAny<string>(), It.IsAny<int>()));

        fixture = new Fixture();

        sut = new WeatherForecastController(loggerMock.Object, weatherForecastServiceMock.Object);
        sut.ControllerContext = new ControllerContext();
        sut.ControllerContext.HttpContext = new DefaultHttpContext();
    }

    [Test]
    public async Task GetWeatherForecast_ShouldCallWithCorrectParametersAndReturn200()
    {
        var cityParam = fixture.Create<string>();
        var daysAheadParam = fixture.Create<int>();

        setupMockGetWeatherForecastAsync
            .ReturnsAsync(fixture.Create<WeatherForecastModel>())
            .Verifiable();

        await sut.GetWeatherForecast(cityParam, daysAheadParam);

        Assert.That(sut.Response.StatusCode, Is.EqualTo(StatusCodes.Status200OK));

        weatherForecastServiceMock.Verify(x => x.GetWeatherForecastAsync(cityParam, daysAheadParam), Times.Once);
    }
}