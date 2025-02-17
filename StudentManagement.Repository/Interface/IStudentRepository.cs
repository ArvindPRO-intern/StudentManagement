using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Repository.Entities;

namespace StudentManagement.Repository.Interface
{
    public interface IStudentRepository
    {
        Task<List<StudentInfo>> GetAll();

        Task<StudentInfo> GetByStudentId(Guid StudentId);
        Task<IEnumerable<StudentInfo>> GetByClassSection(string Class_Section);

        Task<StudentInfo> DeleteStudentById(Guid StudentId);
        Task<StudentInfo> CreateStudent(StudentInfo product);
    }
}
