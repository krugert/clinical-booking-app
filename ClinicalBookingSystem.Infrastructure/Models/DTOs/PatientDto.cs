using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalBookingSystem.Infrastructure.Models.DTOs
{
    public class PatientDto
    {
        public long IdNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
    }
}
