using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.ViewModel
{
    public class StudentContactInfoModel
    {
        [Key]
        [Required]
        public Guid StudentId { get; set; }
        public string ContactName { get; set; }
        public long ContactNumber { get; set; }

        [Display(Name = "Enter EmialId")]
        public string ContactEmailId { get; set; }
    }
}
