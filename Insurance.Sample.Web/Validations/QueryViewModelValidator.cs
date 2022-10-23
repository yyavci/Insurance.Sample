using FluentValidation;
using Insurance.Sample.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.Sample.Web.Validations
{
    public class QueryViewModelValidator : AbstractValidator<QueryViewModel>
    {
        public QueryViewModelValidator()
        {

            RuleFor(f => f.Tckn).NotEmpty().WithMessage("TC Kimlik Numarası boş olamaz.");
            RuleFor(f => f.Tckn).Matches(@"^\d{11}$").WithMessage("TC Kimlik Numarası 11 haneli ve rakamlardan oluşmalıdır.");
            RuleFor(f => f.Tckn).Length(11).WithMessage("TC Kimlik Numarası 11 haneli olmalıdır.");
        }
    }
}