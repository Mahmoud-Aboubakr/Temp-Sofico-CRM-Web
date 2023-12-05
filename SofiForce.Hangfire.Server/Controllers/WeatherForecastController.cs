using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace SofiForce.Hangfire.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public string Get()
        {
            //Fire - and - Forget Job - this job is executed only once
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Welcome to Shopping World!"));

            return $"Job ID: {jobId}. Welcome mail sent to the user!";
        }
    }
}