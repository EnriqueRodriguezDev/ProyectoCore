using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistencia;

namespace WebAPI.Controllers;

//http://localhost:5000/WeatherForecast -> 

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly CursosOnlineContext context;
    public WeatherForecastController(CursosOnlineContext _context){
        context = _context;
    }

    [HttpGet]
    public IEnumerable<Curso> GetCursos(){
        return context.Curso.ToList();
    }
}
