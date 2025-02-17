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
    public class StudentContactRepository: IStudentContactRepository
    {
        private readonly AppDbContext _dbContext;
        public StudentContactRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StudentContactInfo>> GetAll()
        {
            return await _dbContext.StudentContacts.ToListAsync();
        }
        public async Task<StudentContactInfo> GetByStudentId(Guid studentId)
        {
            return await _dbContext.StudentContacts.FirstOrDefaultAsync(studentInfo => studentInfo.StudentId == studentId);
        }

        public async Task<StudentContactInfo> CreateStudentContact(StudentContactInfo studentContactInfo)
        {
            await _dbContext.StudentContacts.AddAsync(studentContactInfo);
            await _dbContext.SaveChangesAsync();
            return studentContactInfo;
        }

        public async Task<StudentContactInfo> DeleteStudentContactById(Guid studentId)
        {
            StudentContactInfo studentContactInfo = await _dbContext.StudentContacts.FirstOrDefaultAsync(studentInfo => studentInfo.StudentId == studentId);
            _dbContext.StudentContacts.Remove(studentContactInfo);
            await _dbContext.SaveChangesAsync();
            return studentContactInfo;
        }

    }
}
