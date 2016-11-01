using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mettal.Models.Business
{
    public class AppSettings
    {
        // locations
        public string AddressOffice { get; set; }
        public string AddressSklad { get; set; }
        public string OfficeMapUrl { get; set; }
        public string SkladMapUrl { get; set; }

        // contacts
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Recvisits { get; set; }

        // worktime
        public string Worktime1 { get; set; }
        public string Worktime2 { get; set; }
        public string Worktime3 { get; set; }

        // manual
        public string ManualSubheader { get; set; }
        public string ManualAbout { get; set; }
    }
}