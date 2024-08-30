using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorRules:AbstractValidator<Author>
    {
        public AuthorRules()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorPhoneNumber).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorPassWord).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorMail).MaximumLength(100).WithMessage("Maksimum karakter geçilemez");
            RuleFor(x => x.AuthorName).MaximumLength(100).WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorTitle).MaximumLength(100).WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorPhoneNumber).MaximumLength(20).WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorImage).MaximumLength(100).WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorAbout).MaximumLength(500).WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorPassWord).MaximumLength(100).WithMessage("Boş geçilemez");
            RuleFor(x => x.AuthorMail).MaximumLength(100).WithMessage("Boş geçilemez");

        }
    }
}
