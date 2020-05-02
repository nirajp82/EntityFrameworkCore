using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
    }
}
