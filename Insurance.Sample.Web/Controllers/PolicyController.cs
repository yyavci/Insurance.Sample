using FluentValidation.Results;
using Insurance.Sample.Entity;
using Insurance.Sample.Entity.Model;
using Insurance.Sample.Service;
using Insurance.Sample.Web.Validations;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Insurance.Sample.Entity.Enums;

namespace Insurance.Sample.Web.Controllers
{
    public class PolicyController : BaseController
    {
        private readonly IPolicyService policyService;

        public PolicyController(
            IPolicyService policyService
            )
        {
            this.policyService = policyService;
        }

        public ActionResult Query()
        {
            var viewModel = new QueryViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Query(QueryViewModel model)
        {
            if (!ValidateViewModel(new QueryViewModelValidator(), model))
                return View(model);
            
            return RedirectToAction("VehiclePolicyOffers", "Policy", new { tckn = model.Tckn });
        }


        public ActionResult VehiclePolicyOffers(long? referenceKey , string tckn)
        {
            var model = new PolicyOfferViewModel();

            try
            {
                var response = policyService.ListPolicyOffers(new GetOfferModel()
                {
                    InsuranceType = InsuranceType.Vehicle,
                    ReferenceKey = referenceKey,
                    Tckn = tckn
                });

                model.Offers = response.Data;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            
            
            return View(model);
        }
    }
}