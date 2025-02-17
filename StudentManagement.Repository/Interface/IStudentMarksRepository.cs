using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Repository.Entities;

namespace StudentManagement.Repository.Interface
{
    public interface IStudentMarksRepository
    {
        Task<List<StudentMarks>> GetAll();

        Task<StudentMarks> GetByStudentId(Guid StudentId);

        Task<StudentMarks> DeleteStudentMarksById(Guid StudentId);
        Task<StudentMarks> CreateStudentMarks(StudentMarks studentMarks);
    }
}
