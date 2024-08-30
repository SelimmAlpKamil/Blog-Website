using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SubscribeRules:AbstractValidator<Subscribe>
    {
        public SubscribeRules()
        {
            RuleFor(x=>x.MailName).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x=>x.MailName).MinimumLength(5).WithMessage("Minimum karakterden az karakter girilemez");
        }
    }
}
