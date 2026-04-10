using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicalBookingSystem.Infrastructure.Models.Domain
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required(ErrorMessage = "The patient's id is required.")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "The clinics id is required.")]
        public int ClinicId { get; set; }
        [Required(ErrorMessage = "The booking date is required.")]
        public DateOnly BookingDate { get; set; }
        [Required(ErrorMessage = "The start time is required.")]
        public TimeOnly StartTime { get; set; }
        [Required(ErrorMessage = "The end time is required.")]
        public TimeOnly EndTime { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }

        // Navigation Property
        public Clinic Clinic { get; set; }
    }
}
