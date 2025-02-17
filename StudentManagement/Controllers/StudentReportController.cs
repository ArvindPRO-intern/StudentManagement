using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.ViewModel;
using StudentManagement.Services.Implementation;
using StudentManagement.Services.Interface;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentReportController : ControllerBase
    {
        private readonly IStudentReportServices _studentReportServices;
        public StudentReportController(IStudentReportServices studentReportServices)
        {
            _studentReportServices = studentReportServices;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<StudentReportModel> studentsReport = await _studentReportServices.GetAll();
            return Ok(studentsReport);
        }

        [HttpGet("getById/{{studentId}}")]
        public async Task<IActionResult> GetById(Guid studentId)
        {
            StudentReportModel studentReportInfo = await _studentReportServices.GetById(studentId);
            return Ok(studentReportInfo);
        }


        [HttpPost("createStudentReport")]
        public async Task<IActionResult> CreateStudentReport([FromBody] StudentReportModel createstudentReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            StudentReportModel studentsReportInfo = await _studentReportServices.CreateStudentReport(createstudentReport);
            return Ok(studentsReportInfo);
        }

        [HttpDelete("DeleteStudentReportById/{{studentId}}")]
        public async Task<IActionResult> DeleteStudentReportById(Guid studentId)
        {
            StudentReportModel studentReportInfo = await _studentReportServices.DeleteStudentReportById(studentId);
            return Ok(studentReportInfo);
        }
    }
}
