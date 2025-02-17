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
    public class StudentMarksRepository:IStudentMarksRepository
    {
        private readonly AppDbContext _dbContext;
        public StudentMarksRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<StudentMarks>> GetAll()
        {
            return await _dbContext.StudentMarks.ToListAsync();
        }
        public async Task<StudentMarks> GetByStudentId(Guid studentId)
        {
            return await _dbContext.StudentMarks.FirstOrDefaultAsync(studentInfo => studentInfo.StudentId == studentId);
        }

        public async Task<StudentMarks> CreateStudentMarks(StudentMarks studentMarks)
        {
            await _dbContext.StudentMarks.AddAsync(studentMarks);
            await _dbContext.SaveChangesAsync();
            return studentMarks;
        }

        public async Task<StudentMarks> DeleteStudentMarksById(Guid studentId)
        {
            StudentMarks studentMarks = await _dbContext.StudentMarks.FirstOrDefaultAsync(studentInfo => studentInfo.StudentId == studentId);
            _dbContext.StudentMarks.Remove(studentMarks);
            await _dbContext.SaveChangesAsync();
            return studentMarks;
        }
    }
}
