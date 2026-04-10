using ClinicalBookingSystem.Infrastructure.Interfaces;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalBookingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IPatientService patientService) : ControllerBase
    {
        [Authorize]
        [HttpPost("create-patient")]
        public async Task<ActionResult> CreatePatient(PatientDto request)
        {
            await patientService.CreatePatient(request);

            return Ok();
        }
    }
}
