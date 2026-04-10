using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalBookingSystem.Infrastructure.Validators
{
    public class AuthValidator : AbstractValidator<UserDto>
    {
        public AuthValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
