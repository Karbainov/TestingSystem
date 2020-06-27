using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestingSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger<StatisticsController> _logger;

        public StatisticsController(ILogger<StatisticsController> logger)
        {
            _logger = logger;
        }

    }
}