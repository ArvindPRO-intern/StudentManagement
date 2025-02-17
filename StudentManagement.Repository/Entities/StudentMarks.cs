using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repository.Entities
{
    public class StudentMarks
    {
        [Key]
        [Required]
        public Guid StudentId { get; set; }
        public string Class_Section { get; set; }
        public string Subject1 { get; set; }
        public float Subject1_percentage { get; set; }
        public char Subject1_Grade { get; set; }
        public string Subject2 { get; set; }
        public float Subject2_percentage { get; set; }
        public char Subject2_Grade { get; set; }
        public string Subject3 { get; set; }
        public float Subject3_percentage { get; set; }
        public char Subject3_Grade { get; set; }
    }
}
