using ClinicalBookingSystem.Infrastructure.Interfaces;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalBookingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        private readonly IValidator<UserDto> _validator;

        public DashboardController(IDashboardService dashboardService, IValidator<UserDto> validator)
        {
            _dashboardService = dashboardService;
            _validator = validator;
        }

        [Authorize]
        [HttpPost("dashboard")]
        public async Task<IActionResult> Dashboard(UserDto request)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            try
            {
                await _dashboardService.DashboardAsync(request);
                return Ok(new { message = "Successfully navigated to dashboard." });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
        }
    }
}
