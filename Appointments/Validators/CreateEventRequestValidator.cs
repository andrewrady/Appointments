using Appointments.Representations;
using FluentValidation;

namespace Appointments.Validators;

public class CreateEventRequestValidator : AbstractValidator<EventCreateRequest>
{
   public CreateEventRequestValidator()
   {
      RuleFor(x => x.Title)
         .NotEmpty().WithMessage("Title is required.")
         .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
   }
}