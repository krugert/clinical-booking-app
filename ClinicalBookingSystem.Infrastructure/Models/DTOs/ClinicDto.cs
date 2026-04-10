using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalBookingSystem.Infrastructure.Models.DTOs
{
    public class ClinicDto
    {
        public string ClinicName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
    }
}
