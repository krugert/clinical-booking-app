using ClinicalBookingSystem.Infrastructure.Models.Domain;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;

namespace ClinicalBookingSystem.Infrastructure.Interfaces
{
    public interface IClinicService
    {
        Task<Clinic?> CreateClinic(ClinicDto clinic);
        Task<List<Clinic>> GetClinics();
    }
}
