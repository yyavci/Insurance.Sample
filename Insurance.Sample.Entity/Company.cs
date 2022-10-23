using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Insurance.Sample.Entity.Enums;

namespace Insurance.Sample.Entity
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public string LogoUrl { get; set; }
        public string Assembly { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PolicyOffer> PolicyOffers { get; set; }
    }
}
