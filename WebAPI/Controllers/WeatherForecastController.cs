using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers;

//http://localhost:5000/WeatherForecast -> 

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> GetVs(){
        string[] nombres = new[]{"Fabian", "Rolando", "Maria", "Rebeca"};
        return nombres;
    }
}
