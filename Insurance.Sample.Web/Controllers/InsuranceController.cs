using FluentValidation.Results;
using Insurance.Sample.Entity;
using Insurance.Sample.Entity.Model;
using Insurance.Sample.Service;
using Insurance.Sample.Web.Validations;
using Microsoft.Ajax.Utilities;
using System;
using System.Transactions;
using System.Web.Mvc;

namespace Insurance.Sample.Web.Controllers
{
    public class InsuranceController : BaseController
    {
        private readonly ICustomerService customerService;
        private readonly IIntegrationService integrationService;
        private readonly IVehicleLicenseService vehicleLicenseService;

        public InsuranceController(
            ICustomerService customerService,
            IIntegrationService integrationService,
            IVehicleLicenseService vehicleLicenseService
            )
        {
            this.customerService = customerService;
            this.integrationService = integrationService;
            this.vehicleLicenseService = vehicleLicenseService;
        }

        #region Customer

        public ActionResult Customer()
        {
            CustomerCreateModel model = new CustomerCreateModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Customer(CustomerCreateModel model)
        {
            if (!ValidateViewModel(new CustomerCreateModelValidator(), model))
                return View(model);
            
            var result = customerService.GetCustomerIdWithVehicleLicense(model.Tckn, model.Plate);

            if (result.Data == 0)
                return RedirectToAction("Create", "Insurance", new { tckn = model.Tckn, plate = model.Plate });

            return RedirectToAction("Create", "Insurance", new { customerId = result.Data, tckn = model.Tckn, plate = model.Plate });
        }

        #endregion

        #region Vehicle Insurance

        public ActionResult Create(int? customerId, string tckn, string plate)
        {
            VehicleInsuranceCreateModel model = new VehicleInsuranceCreateModel();
            try
            {
                if (customerId.HasValue)
                {
                    var result = customerService.GetCustomerVehicleLicense(customerId.Value, plate);
                    model.CustomerId = customerId.Value;
                    model.VehicleLicenseId = result.Data.Id;
                    model.SerialCode = result.Data.SerialCode;
                    model.SerialNo = result.Data.SerialNo;
                }
                model.Tckn = tckn;
                model.Plate = plate;

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleInsuranceCreateModel model)
        {

            if (!ValidateViewModel(new VehicleInsuranceCreateValidator(), model))
                return View(model);
            
            try
            {
                long referenceKey = DateTime.Now.Ticks;

                using (TransactionScope transaction = new TransactionScope())
                {

                    if (model.CustomerId == 0)
                    {
                        var addCustomerResponse = customerService.AddNewCustomer(model.Tckn);
                        if (!addCustomerResponse.Success)
                            throw new Exception("Kullanıcı eklenemedi.Hata:" + addCustomerResponse.Message);

                        model.CustomerId = addCustomerResponse.Data;
                    }

                    if (model.VehicleLicenseId == 0)
                    {
                        var addVehicleLicenseResponse = vehicleLicenseService.AddNewVehicleLicense(new VehicleLicenseModel()
                        {
                            CustomerId = model.CustomerId,
                            Plate = model.Plate,
                            SerialCode = model.SerialCode,
                            SerialNo = model.SerialNo
                        });
                        if (!addVehicleLicenseResponse.Success)
                            throw new Exception("Araç eklenemedi.Hata:" + addVehicleLicenseResponse.Message);

                        model.VehicleLicenseId = addVehicleLicenseResponse.Data;
                    }

                    var offerResults = integrationService.GetInsuranceCompanyOffers(Enums.InsuranceType.Vehicle, model.CustomerId, referenceKey);

                    if (!offerResults.Success)
                        throw new Exception("Teklif alınamadı.Hata:" + offerResults.Message);


                    transaction.Complete();
                }

                return RedirectToAction("VehiclePolicyOffers", "Policy", new { referenceKey = referenceKey, tckn = model.Tckn });

            }
            catch (Exception ex)
            {
                //log exception
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        #endregion
    }
}