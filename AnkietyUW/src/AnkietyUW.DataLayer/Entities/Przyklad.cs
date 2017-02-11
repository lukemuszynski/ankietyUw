using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.DataLayer.Entities
{
    public class Przyklad
    {
        public string Guid { get; set; }
        public string Nazwa { get; set; }
        public int LiczbaPrzykladow { get; set; }
        public DateTime DateTimeZrobieniaPrzykladu { get; set; }
        public int UkrytaLiczbaPrzykladow { get; set; }
    }
}
