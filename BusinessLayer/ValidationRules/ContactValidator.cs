using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");

        }
    }
}
