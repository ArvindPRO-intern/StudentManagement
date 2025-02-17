using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Models.ViewModel;

namespace StudentManagement.Services.Interface
{
    public interface IStudentReportServices
    {
        Task<List<StudentReportModel>> GetAll();

        Task<StudentReportModel> GetById(Guid studentId);

        Task<StudentReportModel> DeleteStudentReportById(Guid studentId);
        Task<StudentReportModel> CreateStudentReport(StudentReportModel productModel);
    }
}
