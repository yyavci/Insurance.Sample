using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Insurance.Sample.Entity.Enums;

namespace Insurance.Sample.Entity.Model
{
    public class GetOfferModel
    {
        public string Tckn { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public long? ReferenceKey { get; set; }
    }
}
