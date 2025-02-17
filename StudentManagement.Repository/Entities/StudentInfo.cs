using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repository.Entities
{
    public class StudentInfo
    {
        [Key]
        [Required]
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string Class_Section { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date of Birthday")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        //public int Age { get; set; }
        public string BloodGroup { get; set; }
    }
}
