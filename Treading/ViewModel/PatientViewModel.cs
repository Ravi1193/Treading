using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Treading.ViewModel
{
    public class PatientViewModel
    {
        public int id { get; set; }

        public string pName { get; set; }

        public string gender { get; set; }

        public DateTime regOn { get; set; }
    }
}