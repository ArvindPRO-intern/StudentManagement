using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagement.Models.ViewModel;
using StudentManagement.Repository.Entities;

namespace StudentManagement.Services
{
    public class AutoMapping:Profile    
    {
        public AutoMapping() 
        {
            CreateMap<StudentInfo, StudentInfoModel>().ReverseMap();
            CreateMap<StudentContactInfo, StudentContactInfoModel>().ReverseMap();
            CreateMap<StudentMarks, StudentMarksModel>().ReverseMap();
            CreateMap<StudentReport, StudentReportModel>().ReverseMap();
        }
    }
}
