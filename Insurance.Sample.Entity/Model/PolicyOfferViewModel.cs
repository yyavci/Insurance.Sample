using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Entity.Model
{
    public class PolicyOfferViewModel
    {
        public PolicyOfferViewModel()
        {
            Offers = new List<PolicyOfferModel>();
        }
        public List<PolicyOfferModel> Offers { get; set; }
    }
}
