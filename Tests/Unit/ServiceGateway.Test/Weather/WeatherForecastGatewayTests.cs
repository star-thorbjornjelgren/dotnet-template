using AutoFixture;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using ServiceGateway.Weather;
using System;
using System.Net;
using System.Net.Http.Headers;

namespace ServiceGateway.Test.Weather;

public class Tests
{
    WeatherForecastGateway sut;

    Mock<HttpMessageHandler> httpMessageHandlerMock;
    Moq.Language.Flow.ISetup<HttpMessageHandler, Task<HttpResponseMessage>> setupMockGetAsync;

    string baseAddress = "https://example.com";
    string apiKey = "123MockApiKey";

    Fixture fixture;

    [SetUp]
    public void Setup()
    {
        httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        setupMockGetAsync = httpMessageHandlerMock.Protected()
           .Setup<Task<HttpResponseMessage>>(
              "SendAsync",
              ItExpr.IsAny<HttpRequestMessage>(),
              ItExpr.IsAny<CancellationToken>()
           );

        var httpClient = new HttpClient(httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri(baseAddress),
        };

        fixture = new Fixture();

        sut = new WeatherForecastGateway(httpClient, apiKey);
    }

    [Test]
    public async Task GetWeatherForecastAsync_ShouldReturnCorrectModel()
    {
        var requestParam = fixture.Create<WeatherForecastRequest>();
        var httpClientResponse = fixture.Create<WeatherForecastResponse>();

        setupMockGetAsync.ReturnsAsync(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonConvert.SerializeObject(httpClientResponse), System.Text.Encoding.UTF8, MediaTypeHeaderValue.Parse("application/json"))
        });

        var result = await sut.GetAsync(requestParam);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Location);
        Assert.IsNotNull(result.Current);
        Assert.IsNotNull(result.Forecast);

        Assert.That(httpClientResponse.Location.Name, Is.EqualTo(result.Location.Name));

        httpMessageHandlerMock
            .Protected()
            .Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req => 
                req.Method == HttpMethod.Get  // we expected a GET request
                && req.RequestUri == new Uri($"{baseAddress}/forecast.json?key={apiKey}&q={requestParam.City}&days={requestParam.DaysAhead}&aqi={requestParam.AirQualityData}&alerts={requestParam.Alerts}") // to this uri
           ),
           ItExpr.IsAny<CancellationToken>());
    }
}