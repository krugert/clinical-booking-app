using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicalBookingSystem.Infrastructure.Models.Domain
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "The patient's ID Number is required.")]
        public long IdNumber { get; set; }
        [Required(ErrorMessage = "The patient's first name is required.")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "The patient's last name is required.")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "The patient's phone number is required.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please provide a valid email address.")]
        public string EmailAddress { get; set; } = string.Empty;

        // Optional: Collection navigation property
        public ICollection<Booking> Bookings { get; set; }
    }
}
