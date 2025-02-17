using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.ViewModel;
using StudentManagement.Services.Implementation;
using StudentManagement.Services.Interface;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentContactInfoController : ControllerBase
    {
        private readonly IStudentContactServices _studentContactServices;
        public StudentContactInfoController(IStudentContactServices studentContactServices)
        {
            _studentContactServices = studentContactServices;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<StudentContactInfoModel> studentsContactInfo = await _studentContactServices.GetAll();
            return Ok(studentsContactInfo);
        }

        [HttpGet("getById/{{studentId}}")]
        public async Task<IActionResult> GetById(Guid studentId)
        {
            StudentContactInfoModel studentContactInfo = await _studentContactServices.GetByStudentId(studentId);
            return Ok(studentContactInfo);
        }


        [HttpPost("createConatactInfoForStudent")]
        public async Task<IActionResult> CreateConatactInfoForStudent([FromBody] StudentContactInfoModel createstudentcontact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            StudentContactInfoModel studentsContactInfo = await _studentContactServices.CreateStudentContact(createstudentcontact);
            return Ok(studentsContactInfo);
        }

        [HttpDelete("DeleteStudentContactById/{{studentId}}")]
        public async Task<IActionResult> DeleteStudentContactById(Guid studentId)
        {
            StudentContactInfoModel studentContactInfo = await _studentContactServices.DeleteStudentContactById(studentId);
            return Ok(studentContactInfo);
        }
    }
}
