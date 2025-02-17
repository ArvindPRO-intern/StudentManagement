using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Repository.Entities;

namespace StudentManagement.Repository.Interface
{
    public interface IStudentReportRepository
    {
        Task<List<StudentReport>> GetAll();

        Task<StudentReport> GetByStudentId(Guid StudentId);

        Task<StudentReport> DeleteStudentReportById(Guid StudentId);
        Task<StudentReport> CreateStudentReport(StudentReport studentReport);
    }
}
