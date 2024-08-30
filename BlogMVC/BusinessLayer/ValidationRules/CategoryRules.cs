using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryRules:AbstractValidator<Category>
    {
        public CategoryRules()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.CategoryName).MaximumLength(100).WithMessage("maksimum karakter sınırı 100");
            RuleFor(x => x.CategoryName).MinimumLength(1).WithMessage("minimum karakter sınırı 1");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.CategoryDescription).MaximumLength(1000).WithMessage("maksimum karakter sınırı 1000");
            RuleFor(x => x.CategoryDescription).MinimumLength(5).WithMessage("minimum karakter sınırı 5");
        }
    }
}
