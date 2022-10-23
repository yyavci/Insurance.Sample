using Insurance.Sample.Data;
using Insurance.Sample.Entity;
using Insurance.Sample.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Insurance.Sample.Entity.Enums;

namespace Insurance.Sample.Service
{
    public class PolicyService : IPolicyService
    {
        private readonly IRepository<PolicyOffer> policyOfferRepository;

        public PolicyService(
            IRepository<PolicyOffer> policyOfferRepository
            )
        {
            this.policyOfferRepository = policyOfferRepository;
        }


        public ServiceResponse<List<PolicyOfferModel>> ListPolicyOffers(GetOfferModel model)
        {
            if (model == null)
                throw new NullReferenceException("GetOfferModel cannot be null!");
            
            if (model.ReferenceKey.HasValue && model.ReferenceKey == 0)
                throw new ArgumentException("ReferenceKey must be greater than 0!");

            var response = new ServiceResponse<List<PolicyOfferModel>>();

            var query = policyOfferRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(model.Tckn))
                query = query.Where(f => f.Customer.Tckn.Equals(model.Tckn));

            if (model.ReferenceKey.HasValue)
                query = query.Where(f => f.ReferenceKey == model.ReferenceKey.Value);

            var data = query.Select(f => new PolicyOfferModel()
            {
                Description = f.Description,
                Price = f.Price,
                CreatedOnUtc = f.CreatedOnUtc,
                CompanyName = f.Company.Name,
                CompanyLogoUrl = f.Company.LogoUrl
            }).ToList();

            response.Data = data;

            return response;
        }

    }
}
