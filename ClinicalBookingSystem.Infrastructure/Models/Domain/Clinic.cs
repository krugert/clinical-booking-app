using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicalBookingSystem.Infrastructure.Models.Domain
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        [Required(ErrorMessage = "The clinics name is required.")]
        public string ClinicName { get; set; } = string.Empty;
        [Required(ErrorMessage = "The clinics phone number is required.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please provide a valid email address.")]
        public string EmailAddress { get; set; } = string.Empty;

        // Optional: Collection navigation property
        public ICollection<Booking> Bookings { get; set; }
    }
}
