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
    public class StudentReportServices :IStudentReportServices
    {
        private readonly IStudentReportRepository _studentReportRepo;
        private readonly IMapper _mapper;
        public StudentReportServices(IStudentReportRepository studentReportServices, IMapper mapper)
        {
            _studentReportRepo = studentReportServices;
            _mapper = mapper;
        }
        public async Task<List<StudentReportModel>> GetAll()
        {
            List<StudentReport> studentReports = await _studentReportRepo.GetAll();
            List<StudentReportModel> studentReportModels = _mapper.Map<List<StudentReportModel>>(studentReports);
            return studentReportModels;
        }

        public async Task<StudentReportModel> GetById(Guid studentId)
        {
            StudentReport studentReport = await _studentReportRepo.GetByStudentId(studentId);
            StudentReportModel studentReportModel = _mapper.Map<StudentReportModel>(studentReport);
            return studentReportModel;
        }

        public async Task<StudentReportModel> CreateStudentReport(StudentReportModel studentReportModel)
        {
            StudentReport newstudentReport = _mapper.Map<StudentReport>(studentReportModel);
            newstudentReport.StudentId = Guid.NewGuid();
            StudentReport createdStudentReport = await _studentReportRepo.CreateStudentReport(newstudentReport);
            return _mapper.Map<StudentReportModel>(createdStudentReport);
        }

        public async Task<StudentReportModel> DeleteStudentReportById(Guid studentId)
        {
            StudentReport studentReport = await _studentReportRepo.DeleteStudentReportById(studentId);
            StudentReportModel studentReportModel = _mapper.Map<StudentReportModel>(studentReport);
            return studentReportModel;
        }
    }
}
