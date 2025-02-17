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
    public class StudentRepository :IStudentRepository
    {
        private readonly AppDbContext _dbContext;
        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StudentInfo>> GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }
        public async Task<StudentInfo> GetByStudentId(Guid studentId)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(studentInfo => studentInfo.StudentId == studentId);
        }

        public async Task<IEnumerable<StudentInfo>> GetByClassSection(string classSection)
        {
            return await _dbContext.Students.Where(studentInfo => studentInfo.Class_Section == classSection).ToListAsync();
        }

        public async Task<StudentInfo> CreateStudent(StudentInfo studentInfo)
        {
            await _dbContext.Students.AddAsync(studentInfo);
            await _dbContext.SaveChangesAsync();
            return studentInfo;
        }

        public async Task<StudentInfo> DeleteStudentById(Guid studentId)
        {
            StudentInfo studentInfo = await _dbContext.Students.FirstOrDefaultAsync(studentInfo => studentInfo.StudentId == studentId);
            _dbContext.Students.Remove(studentInfo);
            await _dbContext.SaveChangesAsync();
            return studentInfo;
        }
    }
}
