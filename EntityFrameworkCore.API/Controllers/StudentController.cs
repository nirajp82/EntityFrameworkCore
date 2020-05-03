﻿using EntityFrameworkCore.Nucleus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        #region Members
        private ILogger<StudentController> _logger { get; }
        private IStudentEngine _studentEngine { get; }
        #endregion


        #region Constructor
        public StudentController(ILogger<StudentController> logger, IStudentEngine studentEngine)
        {
            _logger = logger;
            _studentEngine = studentEngine;
        }
        #endregion

        #region Action Methods
        [HttpGet()]
        public IActionResult Get()
        {
            var students = _studentEngine.FindAll();
            if (students?.Any() == true)
                return Ok(students);
            else
                return NoContent();
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> Get(Guid studentId)
        {
            var student = await _studentEngine.FindAsync(studentId);
            if (student != null)
                return Ok(student);
            else
                return NotFound();
        }
        #endregion
    }
}
