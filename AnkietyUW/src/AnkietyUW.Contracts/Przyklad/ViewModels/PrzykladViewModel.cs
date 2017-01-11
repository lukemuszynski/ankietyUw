using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Contracts.Przyklad.ViewModels
{
    public class PrzykladViewModel
    {

        public Guid Guid { get; set; }
        public string Nazwa { get; set; }
        public int LiczbaPrzykladow { get; set; }
        public DateTime DateTimeZrobieniaPrzykladu { get; set; }

    }
}
