using Insurance.Sample.Data;
using Insurance.Sample.Entity;
using Insurance.Sample.Integration.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Integration
{
    public class BCompanyIntegrationService : ICompanyIntegrationService
    {
        private readonly IRepository<PolicyOffer> policyOfferRepository;
        private readonly IRepository<Company> companyRepository;
        public BCompanyIntegrationService(
            IRepository<PolicyOffer> policyOfferRepository,
            IRepository<Company> companyRepository
            )
        {
            this.policyOfferRepository = policyOfferRepository;
            this.companyRepository = companyRepository;
        }

        public IntegrationServiceResponseModel CalculateOffer(CompanyRequestModel companyRequestModel)
        {
            var responseModel = new IntegrationServiceResponseModel() { Success = true, Message = "" };
            try
            {
                //post to api & get response 
                //response aldığımı varsayıyorum

                var company = companyRepository.Get(companyRequestModel.CompanyId);

                var policyOffer = new PolicyOffer()
                {
                    CompanyId = companyRequestModel.CompanyId,
                    CreatedOnUtc = DateTime.UtcNow,
                    CustomerId = companyRequestModel.CustomerId,
                    Description = "B Firma Teklifi",
                    Price = new Random().Next(100, 2000),
                    ReferenceKey = companyRequestModel.ReferenceKey

                };

                policyOfferRepository.Add(policyOffer);

            }
            catch (Exception ex)
            {
                //TODO log exception message & stack trace
                responseModel.Success = false;
                responseModel.Message = ex.Message;
            }


            return responseModel;
        }
    }
}
