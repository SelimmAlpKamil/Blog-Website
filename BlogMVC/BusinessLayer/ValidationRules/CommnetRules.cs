using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommnetRules : AbstractValidator<Comment>
    {
        public CommnetRules()
        {
          RuleFor(x=>x.CommentText).NotEmpty().WithMessage("Boş geçilemez");
          RuleFor(x=>x.UserName).NotEmpty().WithMessage("Boş geçilemez");
          RuleFor(x=>x.Mail).NotEmpty().WithMessage("Boş geçilemez");
          RuleFor(x=>x.CommentText).MinimumLength(5).WithMessage("Minunm karaterden az olamaz");
          RuleFor(x=>x.UserName).MinimumLength(1).WithMessage("Minunm karaterden az olamaz");
          RuleFor(x=>x.Mail).MinimumLength(5).WithMessage("Minunm karaterden az olamaz");
          RuleFor(x=>x.CommentText).MaximumLength(500).WithMessage("Minunm karaterden az olamaz");
          RuleFor(x=>x.UserName).MaximumLength(100).WithMessage("Minunm karaterden az olamaz");
          RuleFor(x=>x.Mail).MaximumLength(100).WithMessage("Minunm karaterden az olamaz");
          
        }
    }
}
