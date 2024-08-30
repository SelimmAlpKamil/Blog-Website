using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactRules:AbstractValidator<Contact>
    {
        public ContactRules() 
        {
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x=> x.Subject).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x=> x.Message).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x=> x.SurName).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Karakter sınırını geçemez");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Karakter sınırını geçemez");
            RuleFor(x => x.Message).MaximumLength(500).WithMessage("Karakter sınırını geçemez");
            RuleFor(x => x.SurName).MaximumLength(100).WithMessage("Karakter sınırını geçemez");

        }
    }
}
