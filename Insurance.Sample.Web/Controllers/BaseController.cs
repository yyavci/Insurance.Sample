using FluentValidation;
using FluentValidation.Results;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Sample.Web.Controllers
{
    public class BaseController : Controller
    {
        public bool ValidateViewModel<T>(AbstractValidator<T> validator , T model)
        {
            ValidationResult validationResult = validator.Validate(model);
            /*
            VehicleInsuranceCreateValidator validator = new VehicleInsuranceCreateValidator();
            ValidationResult validationResult = validator.Validate(model);
            */
            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(f => ModelState.AddModelError(f.PropertyName, f.ErrorMessage));
            }
            return validationResult.IsValid;
        }

    }
}