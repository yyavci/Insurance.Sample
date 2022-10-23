using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance.Sample.Entity.Model
{

    public class VehicleInsuranceCreateModel
    {
        private string _tckn;
        private string _plate;
        private string _serialCode;

        [DisplayName("Tc Kimlik Numarası")]
        public string Tckn { get { return this._tckn; } set { this._tckn = value.ReplaceInvalidCharsAndToUpper(); } }

        [DisplayName("Plaka")]
        public string Plate { get { return this._plate; } set { this._plate = value.ReplaceInvalidCharsAndToUpper(); } }

        [DisplayName("Ruhsat Seri Kodu")]
        public string SerialCode { get { return this._serialCode; } set { this._serialCode = value.ReplaceInvalidCharsAndToUpper(); } }

        [DisplayName("Ruhsat Seri Numarası")]
        public int SerialNo { get; set; }

        public int CustomerId { get; set; }
        public int VehicleLicenseId { get; set; }
    }
}