using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Entity.Model
{
    public class VehicleLicenseModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Plate { get; set; }
        public string SerialCode { get; set; }
        public int SerialNo { get; set; }
    }
}
