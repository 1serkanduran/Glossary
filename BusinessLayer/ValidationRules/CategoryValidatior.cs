﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayınız");
            
        }
    }
}
