using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutRules:AbstractValidator<About>
    {
        public AboutRules() 
        {
            RuleFor(x => x.AboutContent1).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.AboutContent2).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.AboutImage1).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.AboutImage2).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.AboutContent1).MaximumLength(500).WithMessage("Boş geçilemez");
            RuleFor(x => x.AboutContent2).MaximumLength(500).WithMessage("Boş geçilemez");
            RuleFor(x => x.AboutImage1).MaximumLength(100).WithMessage("Boş geçilemez");
            RuleFor(x => x.AboutImage2).MaximumLength(100).WithMessage("Boş geçilemez");
        }
    }
}
