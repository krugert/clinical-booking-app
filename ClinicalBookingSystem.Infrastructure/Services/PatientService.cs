using ClinicalBookingSystem.Infrastructure.Data;
using ClinicalBookingSystem.Infrastructure.Interfaces;
using ClinicalBookingSystem.Infrastructure.Models.Domain;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using Microsoft.Extensions.Configuration;

namespace ClinicalBookingSystem.Infrastructure.Services
{
    public class PatientService(AppDbContext context, IConfiguration configuration) : IPatientService
    {
        public async Task<Patient?> CreatePatient(PatientDto request)
        {
            var patient = new Patient
            {
                IdNumber = request.IdNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress
            };

            context.Patients.Add(patient);
            await context.SaveChangesAsync();

            return patient;
        }
    }
}
