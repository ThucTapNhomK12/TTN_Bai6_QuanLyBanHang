using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagement.Utils
{
    class ComboboxUtils
    {
        public int value { get; set; }
        public string text { get; set; }

        public ComboboxUtils()
        {
        }

        public ComboboxUtils(int _value, string _text)
        {
            this.value = _value;
            this.text = _text;
        }
    }
}
