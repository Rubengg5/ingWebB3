using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeteoController : ControllerBase
    {
        [HttpGet("/diaria/")]
        public ActionResult<string> GetPrevision([FromQuery]Ubicacion ubicacion)
        {
            var client = new RestClient("https://api.open-meteo.com/");
            var request = new RestRequest($"/v1/forecast?latitude={ (ubicacion.lat).ToString().Replace(",",".") }&longitude={(ubicacion.lon).ToString().Replace(",", ".")}&hourly=temperature_2m,precipitation,windspeed_10m", Method.Get);
            var response = client.Execute(request);
            if (response.Content != null)
            {
                return response.Content.ToString();
            }
            else {
                return NotFound();
            }
            }
    }
}
