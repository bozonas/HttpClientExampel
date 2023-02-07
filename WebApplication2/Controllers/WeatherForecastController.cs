using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMeteoHttpClient _meteoHttpClient;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IMeteoHttpClient meteoHttpClient)
        {
            _logger = logger;
            _meteoHttpClient = meteoHttpClient;
        }

        [HttpGet("station")]
        public async Task<StationResponse> GetStation()
        {
            var station = await _meteoHttpClient.GetStation();
            return station;
        }

        [HttpGet("{id}")]
        public IEnumerable<WeatherForecast> Get(int id)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}