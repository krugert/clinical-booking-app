using ClinicalBookingSystem.Infrastructure.Models.Domain;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;

namespace ClinicalBookingSystem.Infrastructure.Interfaces
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
    }
}
