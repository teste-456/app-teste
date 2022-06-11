using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppFinal.Models;

namespace WebAppFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var model = new List<WeatherForecast>();
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var task = Continuations_GetSomeDataAsync();
                var result = task.GetAwaiter().GetResult();
                model = JsonSerializer.Deserialize<List<WeatherForecast>>(result, options);
            }
            catch (Exception ex) {
                model.Add(new WeatherForecast() { Summary = ex.ToString() });

                var url = _configuration.GetSection("AppSettings").GetSection("ApiFinalUrl").Value;
                model.Add(new WeatherForecast() { Summary = url });
            }
            return View(model);
        }

        protected Task<string> Continuations_GetSomeDataAsync()
        {
            var httpClient = new HttpClient();

            var url = _configuration.GetSection("AppSettings").GetSection("ApiFinalUrl").Value;

            var t = httpClient.GetAsync($"{url}/WeatherForecast/", HttpCompletionOption.ResponseHeadersRead);

            return t.Result.Content.ReadAsStringAsync();

            //return t.ContinueWith(t1 =>  t1.Result.Content.ReadAsStringAsync());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
