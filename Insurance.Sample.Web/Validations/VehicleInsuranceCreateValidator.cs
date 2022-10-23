using FluentValidation;
using Insurance.Sample.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.Sample.Web.Validations
{
    public class VehicleInsuranceCreateValidator : AbstractValidator<VehicleInsuranceCreateModel>
    {
        public VehicleInsuranceCreateValidator()
        {

            RuleFor(f => f.Plate).NotEmpty().WithMessage("Plaka boş olamaz.");
            RuleFor(f => f.Plate).MaximumLength(8).WithMessage("Plaka 8 karakterden fazla olamaz.");

            RuleFor(f => f.Tckn).NotEmpty().WithMessage("TC Kimlik Numarası boş olamaz.");
            RuleFor(f => f.Tckn).Matches(@"^\d{11}$").WithMessage("TC Kimlik Numarası 11 haneli ve rakamlardan oluşmalıdır.");
            RuleFor(f => f.Tckn).Length(11).WithMessage("TC Kimlik Numarası 11 haneli olmalıdır.");

            RuleFor(f => f.SerialCode).NotEmpty().WithMessage("Seri Kodu boş olamaz.");
            RuleFor(f => f.SerialCode).Length(2).WithMessage("Seri Kodu 2 karakter olmalıdır.");

            RuleFor(f => f.SerialNo).NotEmpty().WithMessage("Seri Numarası boş olamaz.");
            RuleFor(f => f.SerialNo).LessThanOrEqualTo(999999).WithMessage("Seri numarası 6 haneli olmalıdır.");
            RuleFor(f => f.SerialNo).GreaterThanOrEqualTo(100000).WithMessage("Seri numarası 6 haneli olmalıdır.");
            
        }
    }
}