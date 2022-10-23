using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Entity.Model
{
    public class QueryViewModel
    {
        private string _tckn;

        public string Tckn { get { return this._tckn; } set { this._tckn = value.ReplaceInvalidCharsAndToUpper(); } }
    }
}
