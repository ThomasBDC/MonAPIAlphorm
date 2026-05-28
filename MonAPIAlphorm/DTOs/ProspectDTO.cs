using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace MonAPIAlphorm.DTOs
{
    public class ProspectDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class EditProspectDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class CreateProspectDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Phone(ErrorMessage ="Le téléphone n'est pas valide")]
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class CreateProspectDTOValidator : AbstractValidator<CreateProspectDTO>
    {
        public CreateProspectDTOValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email obligatoire")
                .EmailAddress().WithMessage("L'adresse email n'est pas valide");

            RuleFor(p => p)
                .Must(p => !string.IsNullOrWhiteSpace(p.Email) || !string.IsNullOrWhiteSpace(p.Phone))
                .WithMessage("Error message");
        }
    }
}
