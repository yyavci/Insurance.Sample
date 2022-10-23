using Insurance.Sample.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Insurance.Sample.Entity.Enums;

namespace Insurance.Sample.Service
{
    public interface IIntegrationService
    {
        ServiceResponse<object> GetInsuranceCompanyOffers(InsuranceType insuranceType, int customerId, long referenceKey);
    }
}
