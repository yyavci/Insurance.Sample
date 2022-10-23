using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Insurance.Sample.Entity.Enums;

namespace Insurance.Sample.Integration.Base
{
    public class CompanyRequestModel
    {
        public InsuranceType InsuranceType { get; set; }
        public long ReferenceKey { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }

    }
}
