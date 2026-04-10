using ClinicalBookingSystem.Infrastructure.Data;
using ClinicalBookingSystem.Infrastructure.Interfaces;
using ClinicalBookingSystem.Infrastructure.Models.Domain;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ClinicalBookingSystem.Infrastructure.Services
{
    public class DashboardService(AppDbContext context, IConfiguration configuration) : IDashboardService
    {
        private readonly AppDbContext _context;

        public async Task<TokenResponseDto?> DashboardAsync(UserDto request)
        {
            return null;
        }
    }
}
