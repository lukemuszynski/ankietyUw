using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.DataLayer.Entities
{
    public class Secret
    {
        public string Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public int SeriesNumber { get; set; }
    }
}
