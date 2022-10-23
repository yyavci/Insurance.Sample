using Insurance.Sample.Data;
using Insurance.Sample.Entity;
using Insurance.Sample.Integration.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Insurance.Sample.Entity.Enums;

namespace Insurance.Sample.Service
{
    public class IntegrationService : IIntegrationService
    {
        private readonly IEnumerable<ICompanyIntegrationService> companyIntegrationServices;
        private readonly IRepository<Company> companyRepository;
        public IntegrationService(
            IEnumerable<ICompanyIntegrationService> companyIntegrationServices , 
            IRepository<Company> companyRepository
            )
        {
            this.companyIntegrationServices = companyIntegrationServices;
            this.companyRepository = companyRepository;
        }

        public ServiceResponse<object> GetInsuranceCompanyOffers(InsuranceType insuranceType ,int customerId, long referenceKey)
        {
            if (customerId == 0)
                throw new ArgumentException("customerId boş olamaz!");

            if(referenceKey == 0)
                throw new ArgumentException("referenceKey boş olamaz!");

            if (companyIntegrationServices == null || !companyIntegrationServices.Any())
                return new ServiceResponse<object>() { Success = false, Message = "Sigorta şirketi bulunamadı." };

            var companies = companyRepository.GetAll().Where(f => f.IsActive && f.InsuranceType == insuranceType).ToList();

            if(!companies.Any())
                return new ServiceResponse<object>() { Success = false, Message = "Aktif Sigorta şirketi bulunamadı." };

            bool hasAnySucceed = false;
            string errorMessage = "";

            foreach (var company in companies)
            {
                var integrationService = companyIntegrationServices.Where(f => f.GetType().FullName.Equals(company.Assembly)).FirstOrDefault();

                if (integrationService == null) //not injected - check assembly name or dependency
                    continue;

                var integrationResult = integrationService.CalculateOffer(new CompanyRequestModel()
                {
                    InsuranceType = insuranceType,
                    ReferenceKey = referenceKey,
                    CustomerId = customerId,
                    CompanyId = company.Id
                });

                if (integrationResult.Success)
                    hasAnySucceed = true;
                else
                    errorMessage += integrationResult.Message + Environment.NewLine;

            }

            return new ServiceResponse<object>() { Success = hasAnySucceed, Message = hasAnySucceed ? "" : errorMessage };

        }


    }
}
