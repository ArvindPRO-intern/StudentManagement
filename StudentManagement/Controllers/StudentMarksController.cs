using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.ViewModel;
using StudentManagement.Services.Implementation;
using StudentManagement.Services.Interface;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMarksController : ControllerBase
    {
        private readonly IStudentMarksServices _studentMarksServices;
        public StudentMarksController(IStudentMarksServices studentMarksServices)
        {
            _studentMarksServices = studentMarksServices;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<StudentMarksModel> studentsMarks = await _studentMarksServices.GetAll();
            return Ok(studentsMarks);
        }

        [HttpGet("getById/{{studentId}}")]
        public async Task<IActionResult> GetById(Guid studentId)
        {
            StudentMarksModel studentMarks = await _studentMarksServices.GetByStudentId(studentId);
            return Ok(studentMarks);
        }


        [HttpPost("createStudentMarks")]
        public async Task<IActionResult> CreateStudentMarks([FromBody] StudentMarksModel createstudentMarks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            StudentMarksModel studentsMarks = await _studentMarksServices.CreateStudentMarks(createstudentMarks);
            return Ok(studentsMarks);
        }

        [HttpDelete("DeleteStudentById/{{studentId}}")]
        public async Task<IActionResult> DeleteStudentMarksById(Guid studentId)
        {
            StudentMarksModel studentMarks = await _studentMarksServices.DeleteStudentMarksById(studentId);
            return Ok(studentMarks);
        }
    }
}
