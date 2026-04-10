using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalBookingSystem.Infrastructure.Interfaces
{
    public interface IDashboardService
    {
        Task<TokenResponseDto?> DashboardAsync(UserDto request);
    }
}
