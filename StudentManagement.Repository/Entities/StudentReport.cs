﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repository.Entities
{
    public class StudentReport
    {
        [Key]
        [Required]
        public Guid StudentId { get; set; }
        public string AadharCardNumber { get; set; }
        public bool Term1_Fees { get; set; }
        public bool Term2_Fees { get; set; }
    }
}
