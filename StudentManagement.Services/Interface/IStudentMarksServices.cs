using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Models.ViewModel;

namespace StudentManagement.Services.Interface
{
    public interface IStudentMarksServices
    {
        Task<List<StudentMarksModel>> GetAll();

        Task<StudentMarksModel> GetByStudentId(Guid studentId);

        Task<StudentMarksModel> DeleteStudentMarksById(Guid studentId);
        Task<StudentMarksModel> CreateStudentMarks(StudentMarksModel productModel);
    }
}
