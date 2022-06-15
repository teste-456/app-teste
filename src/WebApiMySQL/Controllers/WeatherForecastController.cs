using Microsoft.AspNetCore.Mvc;

namespace WebApiMySQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastContext _context;

        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IConfiguration Configuration { get; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                        WeatherForecastContext context,
                                        IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var transaction = Elastic.Apm.Agent.Tracer.CurrentTransaction;
            try
            {


                return _context.WeatherForecast.ToList();

            }
            catch (Exception ex)
            {
                transaction.CaptureException(ex);

                var url = Configuration.GetSection("AppSettings").GetSection("Conexao").Value;
                return new List<WeatherForecast>() { new WeatherForecast { Summary = ex.ToString() },
                                                     new WeatherForecast { Summary = url } };
            }
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}