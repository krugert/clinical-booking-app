using ClinicalBookingSystem.Infrastructure.Models.Domain;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;

namespace ClinicalBookingSystem.Infrastructure.Interfaces
{
    public interface IPatientService
    {
        Task<Patient?> CreatePatient(PatientDto patient);
    }
}
