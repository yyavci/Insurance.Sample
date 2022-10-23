using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Tckn { get; set; }

        public virtual ICollection<PolicyOffer> PolicyOffers { get; set; }
        public virtual ICollection<VehicleLicense> VehicleLicenses { get; set; }
    }
}
