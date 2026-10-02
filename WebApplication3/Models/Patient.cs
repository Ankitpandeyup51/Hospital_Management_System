using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Patient
    {

        public int PatientId { get; set; }

        [Required(ErrorMessage = "Please enter patient name")]
        public string PatientName { get; set; }

        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }

        public int? Age { get; set; }

        public string Address { get; set; }

        public string Disease { get; set; }

        public string BloodGroup { get; set; }

        public DateTime AdmissionDate { get; set; }

        public bool IsActive { get; set; }
    }
}