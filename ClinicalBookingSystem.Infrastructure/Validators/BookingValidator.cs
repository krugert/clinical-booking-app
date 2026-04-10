using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using FluentValidation;

namespace ClinicalBookingSystem.App.Validators
{
    public class BookingValidator : AbstractValidator<BookingDto>
    {
        public BookingValidator()
        {
            RuleFor(x => x.PatientId).GreaterThan(0);
            RuleFor(x => x.ClinicId).GreaterThan(0);
            RuleFor(x => x.BookingDate).NotEmpty();
            RuleFor(x => x.StartTime).NotEmpty();
            RuleFor(x => x.EndTime).NotEmpty();
        }
    }
}
