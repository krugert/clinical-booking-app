using ClinicalBookingSystem.Infrastructure.Interfaces;
using ClinicalBookingSystem.Infrastructure.Models.Domain;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalBookingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController(IClinicService clinicService) : ControllerBase
    {
        [Authorize]
        [HttpPost("create-clinic")]
        public async Task<ActionResult> CreateClinic(ClinicDto request)
        {
            await clinicService.CreateClinic(request);

            return Ok();
        }

        [Authorize]
        [HttpGet("get-clinics")]
        public async Task<List<Clinic>> GetClinics()
        {
            var clinics = await clinicService.GetClinics();

            return clinics;
        }
    }
}
