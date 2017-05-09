using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagement.Utils
{
    class ActionForm
    {
        public string key { get; set; }

        public string action { get; set; }

        public ActionForm()
        {

        }

        public ActionForm(string _key, string _action)
        {
            this.key = _key;
            this.action = _action;
        }
    }
}
