using ClinicalBookingSystem.Infrastructure.Data;
using ClinicalBookingSystem.Infrastructure.Interfaces;
using ClinicalBookingSystem.Infrastructure.Models.Domain;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ClinicalBookingSystem.Infrastructure.Services
{
    public class ClinicService(AppDbContext context, IConfiguration configuration) : IClinicService
    {
        public async Task<Clinic?> CreateClinic(ClinicDto request)
        {
            var clinic = new Clinic
            {
                ClinicName = request.ClinicName,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress
            };

            context.Clinics.Add(clinic);
            await context.SaveChangesAsync();

            return clinic;
        }

        public async Task<List<Clinic>> GetClinics()
        {
            var clinics = await context.Clinics.ToListAsync();

            return clinics;
        }
    }
}
