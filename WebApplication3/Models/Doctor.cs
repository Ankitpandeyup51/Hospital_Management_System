using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Specialization { get; set; }

        public int Experience { get; set; }

        public bool IsActive { get; set; }
    }
}