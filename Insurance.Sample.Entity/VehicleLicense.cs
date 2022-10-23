using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Entity
{
    public class VehicleLicense
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Plate { get; set; }
        public string SerialCode { get; set; }
        public int SerialNo { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
