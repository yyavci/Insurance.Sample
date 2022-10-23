using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Integration.Base
{
    public interface ICompanyIntegrationService
    {
        IntegrationServiceResponseModel CalculateOffer(CompanyRequestModel companyRequestModel);
    }
}
