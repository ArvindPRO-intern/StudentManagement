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
    public class StudentMarksServices : IStudentMarksServices
    {
        private readonly IStudentMarksRepository _studentMarksRepo;
        private readonly IMapper _mapper;
        public StudentMarksServices(IStudentMarksRepository studentMarksServices, IMapper mapper)
        {
            _studentMarksRepo = studentMarksServices;
            _mapper = mapper;
        }

        public async Task<List<StudentMarksModel>> GetAll()
        {
            List<StudentMarks> studentMarks = await _studentMarksRepo.GetAll();
            List<StudentMarksModel> studentMarksModels = _mapper.Map<List<StudentMarksModel>>(studentMarks);
            return studentMarksModels;
        }

        public async Task<StudentMarksModel> GetByStudentId(Guid studentId)
        {
            StudentMarks studentMarks = await _studentMarksRepo.GetByStudentId(studentId);
            StudentMarksModel studentMarksModel = _mapper.Map<StudentMarksModel>(studentMarks);
            return studentMarksModel;
        }

        public async Task<StudentMarksModel> CreateStudentMarks(StudentMarksModel studentMarksModel)
        {
            StudentMarks newstudentMarks = _mapper.Map<StudentMarks>(studentMarksModel);
            newstudentMarks.StudentId = Guid.NewGuid();
            StudentMarks createdproduct = await _studentMarksRepo.CreateStudentMarks(newstudentMarks);
            return _mapper.Map<StudentMarksModel>(createdproduct);
        }

        public async Task<StudentMarksModel> DeleteStudentMarksById(Guid studentId)
        {
            StudentMarks studentMarks = await _studentMarksRepo.DeleteStudentMarksById(studentId);
            StudentMarksModel studentMarksModel = _mapper.Map<StudentMarksModel>(studentMarks);
            return studentMarksModel;
        }
    }
}
