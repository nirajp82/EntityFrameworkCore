using EntityFrameworkCore.APIModel;
using EntityFrameworkCore.Nucleus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Fetch list of all students
        /// </summary>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<StudentEntity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            var students = _studentEngine.FindAll();
            if (students?.Any() == true)
                return Ok(students);
            else
                return NoContent();
        }

        /// <summary>
        /// Returns student information for given student id
        /// </summary>
        [HttpGet("{studentId}")]
        [ProducesResponseType(typeof(StudentEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(long studentId)
        {
            var student = await _studentEngine.FindAsync(studentId);
            if (student != null)
                return Ok(student);
            else
                return NotFound();
        }


        [HttpPost]
        [ProducesResponseType(typeof(StudentEntity), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] StudentEntity student)
        {
            student = await _studentEngine.AddAsync(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }


        [HttpPut("{studentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PUT(long studentId, [FromBody] StudentEntity student)
        {
            if (studentId != student.Id)
                return BadRequest();

            _studentEngine.Update(student);
            return NoContent();
        }

        [HttpDelete("{studentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long studentId)
        {
            await _studentEngine.DeleteAsync(studentId);
            return NoContent();
        }
        #endregion
    }
}
