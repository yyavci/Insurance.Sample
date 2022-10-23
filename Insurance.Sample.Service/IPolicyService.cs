using Insurance.Sample.Entity;
using Insurance.Sample.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Service
{
    public interface IPolicyService
    {
        ServiceResponse<List<PolicyOfferModel>> ListPolicyOffers(GetOfferModel model);
    }
}
