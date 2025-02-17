using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Repository.Entities;

namespace StudentManagement.Repository.Interface
{
    public interface IStudentContactRepository
    {
        Task<List<StudentContactInfo>> GetAll();

        Task<StudentContactInfo> GetByStudentId(Guid StudentId);

        Task<StudentContactInfo> DeleteStudentContactById(Guid StudentId);
        Task<StudentContactInfo> CreateStudentContact(StudentContactInfo studentContactInfo);
    }
}
