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
    public class StudentServices:IStudentServices
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        public StudentServices(IStudentRepository studentServices, IMapper mapper)
        {
            _studentRepo =studentServices;
            _mapper = mapper;
        }
        public async Task<List<StudentInfoModel>> GetAll()
        {
            List<StudentInfo> students = await _studentRepo.GetAll();
            List<StudentInfoModel> studentInfoModels = _mapper.Map<List<StudentInfoModel>>(students);
            return studentInfoModels;
        }

        public async Task<StudentInfoModel> GetByStudentId(Guid studentId)
        {
            StudentInfo student = await _studentRepo.GetByStudentId(studentId);
            StudentInfoModel studentInfoModel = _mapper.Map<StudentInfoModel>(student);
            return studentInfoModel;
        }

        public async Task<IEnumerable<StudentInfoModel>> GetByClassSection(string classSection)
        {
            IEnumerable<StudentInfo> students = await _studentRepo.GetByClassSection(classSection);
            IEnumerable<StudentInfoModel> studentInfoModels = _mapper.Map<IEnumerable<StudentInfoModel>>(students);
            return studentInfoModels;
        }

        public async Task<StudentInfoModel> CreateStudent(StudentInfoModel studentInfoModel)
        {
            StudentInfo newstudent = _mapper.Map<StudentInfo>(studentInfoModel);
            newstudent.StudentId = Guid.NewGuid();
            StudentInfo createdproduct = await _studentRepo.CreateStudent(newstudent);
            return _mapper.Map<StudentInfoModel>(createdproduct);
        }

        public async Task<StudentInfoModel> DeleteStudentById(Guid studentId)
        {
            StudentInfo studentInfo = await _studentRepo.DeleteStudentById(studentId);
            StudentInfoModel studentInfoModel = _mapper.Map<StudentInfoModel>(studentInfo);
            return studentInfoModel;
        }
    }
}
