using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("En az 2 karakter olmalıdır");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("En fazla 50 karakter");
            RuleFor(x => x.WriterTitle).MaximumLength(20).WithMessage("En fazla 50 karakter");
        }
    }
}
