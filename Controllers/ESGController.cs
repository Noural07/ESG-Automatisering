using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Frond_end.Models;
using System.Collections.Generic;
using NuGet.Protocol.Core.Types;
using System.Text.Json;
using System.Diagnostics;

namespace Frond_end.Controllers
{
    public class ESGController : Controller
    {
        private readonly HttpClient _httpClient;


        public ESGController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Dashboard()
        {
            List<SensorData> sensorDataList = new List<SensorData>();

            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7252/api/Api");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                sensorDataList = JsonSerializer.Deserialize<List<SensorData>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return View(sensorDataList);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }

        public IActionResult Issues()
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
