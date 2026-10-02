using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Reason { get; set; }

        public string Status { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }
    }
}