using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidatior:AbstractValidator<Writer>
    {
        public WriterValidatior() 
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(x => x.WriterMail).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayınız");
        }
    }
}
