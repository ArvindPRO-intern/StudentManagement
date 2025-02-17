using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.ViewModel;
using StudentManagement.Services.Interface;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoController : ControllerBase

    {
        private readonly IStudentServices _studentServices;
        public StudentInfoController(IStudentServices studentServices) 
        {
            _studentServices = studentServices;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<StudentInfoModel> studentsInfo = await _studentServices.GetAll();
            return Ok(studentsInfo);
        }

        [HttpGet("getById/{{studentId}}")]
        public async Task<IActionResult> GetById(Guid studentId)
        {
            StudentInfoModel studentInfo = await _studentServices.GetByStudentId(studentId);
            return Ok(studentInfo);
        }
        [HttpGet("getByClassSection/{{classsection}}")]
        public async Task<IActionResult> GetByClassSection(string classSection)
        {
            IEnumerable<StudentInfoModel> studentInfo = await _studentServices.GetByClassSection(classSection);
            return Ok(studentInfo);
        }

        [HttpPost("createStudent")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentInfoModel createstudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            StudentInfoModel studentsInfo = await _studentServices.CreateStudent(createstudent);
            return Ok(studentsInfo);
        }

        [HttpDelete("DeleteStudentById/{{studentId}}")]
        public async Task<IActionResult> DeleteStudentById(Guid studentId)
        {
            StudentInfoModel studentInfo = await _studentServices.DeleteStudentById(studentId);
            return Ok(studentInfo);
        }
    }
}
