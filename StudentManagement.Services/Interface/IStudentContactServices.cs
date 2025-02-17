using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Models.ViewModel;

namespace StudentManagement.Services.Interface
{
    public interface IStudentContactServices
    {
        Task<List<StudentContactInfoModel>> GetAll();

        Task<StudentContactInfoModel> GetByStudentId(Guid studentId);

        Task<StudentContactInfoModel> DeleteStudentContactById(Guid studentId);
        Task<StudentContactInfoModel> CreateStudentContact(StudentContactInfoModel studentContactModel);
    }
}
