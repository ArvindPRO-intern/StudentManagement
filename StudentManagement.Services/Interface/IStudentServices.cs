using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Models.ViewModel;

namespace StudentManagement.Services.Interface
{
    public interface IStudentServices
    {
        Task<List<StudentInfoModel>> GetAll();

        Task<StudentInfoModel> GetByStudentId(Guid studentId);

        Task<IEnumerable<StudentInfoModel>> GetByClassSection(string Class_Section);

        Task<StudentInfoModel> DeleteStudentById(Guid studentId);
        Task<StudentInfoModel> CreateStudent(StudentInfoModel productModel);
    }
}
