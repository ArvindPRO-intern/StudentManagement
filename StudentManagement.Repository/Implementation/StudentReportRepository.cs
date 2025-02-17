using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Repository.Entities;
using StudentManagement.Repository.Interface;

namespace StudentManagement.Repository.Implementation
{
    public class StudentReportRepository :IStudentReportRepository
    {
        private readonly AppDbContext _dbContext;
        public StudentReportRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<StudentReport>> GetAll()
        {
            return await _dbContext.StudentReports.ToListAsync();
        }
        public async Task<StudentReport> GetByStudentId(Guid studentId)
        {
            return await _dbContext.StudentReports.FirstOrDefaultAsync(studentInfo => studentInfo.StudentId == studentId);
        }

        public async Task<StudentReport> CreateStudentReport(StudentReport studentReport)
        {
            await _dbContext.StudentReports.AddAsync(studentReport);
            await _dbContext.SaveChangesAsync();
            return studentReport;
        }

        public async Task<StudentReport> DeleteStudentReportById(Guid studentId)
        {
            StudentReport studentInfo = await _dbContext.StudentReports.FirstOrDefaultAsync(studentInfo => studentInfo.StudentId == studentId);
            _dbContext.StudentReports.Remove(studentInfo);
            await _dbContext.SaveChangesAsync();
            return studentInfo;
        }
    }
}
