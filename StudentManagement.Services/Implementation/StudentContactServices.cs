using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagement.Models.ViewModel;
using StudentManagement.Repository.Entities;
using StudentManagement.Repository.Interface;
using StudentManagement.Services.Interface;

namespace StudentManagement.Services.Implementation
{
    public class StudentContactServices : IStudentContactServices
    {
        private readonly IStudentContactRepository _studentContactRepo;
        private readonly IMapper _mapper;
        public StudentContactServices(IStudentContactRepository studentContactServices, IMapper mapper)
        {
            _studentContactRepo = studentContactServices;
            _mapper = mapper;
        }

        public async Task<List<StudentContactInfoModel>> GetAll()
        {
            List<StudentContactInfo> studentContacts = await _studentContactRepo.GetAll();
            List<StudentContactInfoModel> studentContactInfoModels = _mapper.Map<List<StudentContactInfoModel>>(studentContacts);
            return studentContactInfoModels;
        }

        public async Task<StudentContactInfoModel> GetByStudentId(Guid studentId)
        {
            StudentContactInfo student = await _studentContactRepo.GetByStudentId(studentId);
            StudentContactInfoModel studentContactInfoModel = _mapper.Map<StudentContactInfoModel>(student);
            return studentContactInfoModel;
        }

        public async Task<StudentContactInfoModel> CreateStudentContact(StudentContactInfoModel studentContactInfoModel)
        {
            StudentContactInfo newstudentContact = _mapper.Map<StudentContactInfo>(studentContactInfoModel);
            newstudentContact.StudentId = Guid.NewGuid();
            StudentContactInfo createdStudentContact = await _studentContactRepo.CreateStudentContact(newstudentContact);
            return _mapper.Map<StudentContactInfoModel>(createdStudentContact);
        }

        public async Task<StudentContactInfoModel> DeleteStudentContactById(Guid studentId)
        {
            StudentContactInfo studentContactInfo = await _studentContactRepo.DeleteStudentContactById(studentId);
            StudentContactInfoModel studentContactInfoModel = _mapper.Map<StudentContactInfoModel>(studentContactInfo);
            return studentContactInfoModel;
        }
    }
}
