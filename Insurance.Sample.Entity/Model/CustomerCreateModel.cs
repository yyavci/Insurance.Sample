using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Entity.Model
{
    public class CustomerCreateModel
    {
        private string _tckn;
        private string _plate;

        [DisplayName("Tc Kimlik Numarası")]
        public string Tckn { get { return this._tckn; } set { this._tckn = value.ReplaceInvalidCharsAndToUpper(); } }

        [DisplayName("Plaka")]
        public string Plate { get { return this._plate; } set { this._plate = value.ReplaceInvalidCharsAndToUpper(); } }



    }
}
