using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private ILogger<StudentController> _logger { get; }

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
    }
}
