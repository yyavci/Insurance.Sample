using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Entity.Model
{
    public class PolicyOfferModel
    {

        public string Description { get; set; }

        public decimal Price { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public string CompanyName { get; set; }
        public string CompanyLogoUrl { get; set; }


    }
}
