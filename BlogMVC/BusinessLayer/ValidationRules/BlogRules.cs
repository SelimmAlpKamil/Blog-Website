using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogRules: AbstractValidator<Blog>
    {
        public BlogRules() 
        {
            RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x=>x.BlogContent).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x=>x.BlogImage).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x=>x.BlogDate).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x=>x.BlogContent).MaximumLength(100000000).WithMessage("Maksimum karakter sınırı 100000000");
            RuleFor(x=>x.BlogContent).MinimumLength(10).WithMessage("Minimum karakter sınırı 10");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Maksimum karakter sınırı 100");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Minimum karakter sınırı 5");

        }
    }
}
