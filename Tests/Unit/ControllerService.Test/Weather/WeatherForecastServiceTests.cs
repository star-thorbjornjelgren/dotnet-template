using AutoFixture;
using ControllerService.Weather;
using Moq;
using ServiceGateway.Weather;
using static ServiceGateway.Weather.WeatherForecastResponse;

namespace ControllerService.Test.Weather;

public class WeatherForecastServiceTests
{
    WeatherForecastService sut;
    Mock<IWeatherForecastGateway> WeatherForecastGatewayMock;
    Moq.Language.Flow.ISetup<IWeatherForecastGateway, Task<WeatherForecastResponse?>> setupMockGetAsync;

    Fixture fixture;

    [SetUp]
    public void Setup()
    {
        WeatherForecastGatewayMock = new Mock<IWeatherForecastGateway>();
        setupMockGetAsync = WeatherForecastGatewayMock.Setup(x => x.GetAsync(It.IsAny<WeatherForecastRequest>()));

        fixture = new Fixture();

        sut = new WeatherForecastService(WeatherForecastGatewayMock.Object);
    }

    [Test]
    public async Task GetWeatherForecastAsync_ShouldReturnCorrectModel()
    {
        var cityParam = fixture.Create<string>();
        var daysAheadParam = new Random().Next(1,8);

        var locationResponse = fixture
            .Build<GeoLocation>()
            .With(x => x.Name, cityParam)
            .Create();

        var forecastResponse = fixture
            .Build<WeatherForecast>()
            .With(x => x.Forecastday, fixture.CreateMany<Forecastday>(daysAheadParam).ToList())
            .Create();

        var gatewayResponse = fixture
            .Build<WeatherForecastResponse>()
            .With(x => x.Location, locationResponse)
            .With(x => x.Forecast, forecastResponse)
            .Create();

        setupMockGetAsync
            .ReturnsAsync(gatewayResponse)
            .Verifiable();

        var result = await sut.GetWeatherForecastAsync(cityParam, daysAheadParam);

        Assert.That(result.City, Is.EqualTo(cityParam));
        Assert.That(result.Country, Is.EqualTo(locationResponse.Country));

        var firstDayResult = result.Days.First();
        var firstDayResponse = forecastResponse.Forecastday.First();
        Assert.That(firstDayResult.Date, Is.EqualTo(firstDayResponse.Date));
        Assert.That(firstDayResult.MaxtempC, Is.EqualTo(firstDayResponse.Day.MaxtempC));
        Assert.That(firstDayResult.MintempC, Is.EqualTo(firstDayResponse.Day.MintempC));
        
        // Etc....

        WeatherForecastGatewayMock.Verify(x => x.GetAsync(It.Is<WeatherForecastRequest>(x => x.City == cityParam && x.DaysAhead == daysAheadParam)), Times.Once);
    }
}